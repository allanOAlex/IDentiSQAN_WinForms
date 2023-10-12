using AxZKFPEngXControl;
using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zk4500.Abstractions.Interfaces;
using zk4500.Exceptions;
using zk4500.Extensions;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;
using zk4500.Shared.Dtos;
using zk4500.ApiClient;
using System.Text.RegularExpressions;
using zk4500.Helpers.DialogHelpers;
using zk4500.Helpers.BrowserHelpers;

namespace zk4500.Forms
{
    public partial class Login : Form
    {
        private AxZKFPEngX ZkFprint = new AxZKFPEngX();
        private readonly IServiceManager serviceManager;
        private readonly IAuthApiClient authApiClient;

        VerifyFingerPrintRequest verifyFingerPrintRequest = new VerifyFingerPrintRequest();
        VerifyFingerPrintResponse verifyFingerPrintResponse = new VerifyFingerPrintResponse();
        UpdateVerifiedRequest updateVerifiedRequest = new UpdateVerifiedRequest();
        UpdateVerifiedResponse updateVerifiedResponse = new UpdateVerifiedResponse();

        private bool Check;

        private BrowserManager browserManager;

        public Login(IServiceManager ServiceManager, IAuthApiClient AuthApiClient, BrowserManager BrowserManager)
        {
            serviceManager = ServiceManager;
            authApiClient = AuthApiClient;
            browserManager = BrowserManager;

            InitializeComponent();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            labelLoginCaption.Text = $"Pro-Med Biometrics Login";
            Controls.Add(ZkFprint);
            InitialAxZkfp();

        }

        private void InitialAxZkfp()
        {
            try
            {
                ZkFprint.OnImageReceived += OnImageReceived;
                ZkFprint.OnFeatureInfo += OnFeatureInfo;
                ZkFprint.OnEnroll += OnEnroll;

                if (ZkFprint.InitEngine() == 0)
                {
                    ZkFprint.FPEngineVersion = "9";
                    ZkFprint.EnrollCount = 3;
                    AppExtensions.DeviceConnected = 1;
                    ShowHintInfo("Device successfully connected");

                }

            }
            catch (Exception ex)
            {
                ShowHintInfo("Device init err, error: " + ex.Message);
            }
        }

        private void OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            try
            {
                Graphics g = fingerBox.CreateGraphics();
                Bitmap bmp = new Bitmap(fingerBox.Width, fingerBox.Height);
                g = Graphics.FromImage(bmp);
                int dc = g.GetHdc().ToInt32();
                ZkFprint.PrintImageAt(dc, 0, 0, bmp.Width, bmp.Height);
                g.Dispose();
                fingerBox.Image = bmp;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void OnFeatureInfo(object sender, IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            String strTemp = string.Empty;
            try
            {
                if (ZkFprint.EnrollIndex != 1)
                {
                    if (ZkFprint.IsRegister)
                    {
                        if (ZkFprint.EnrollIndex - 1 > 0)
                        {
                            int eindex = ZkFprint.EnrollIndex - 1;
                            strTemp = "Please scan again ..." + eindex;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            ShowHintInfo(strTemp);
        }

        private void OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            try
            {
                if (e.actionResult)
                {
                    string template = ZkFprint.EncodeTemplate1(e.aTemplate);

                    try
                    {
                        verifyFingerPrintRequest.Id = AppExtensions.PatientId;
                        verifyFingerPrintRequest.ImageTemplate = template;
                        buttonLogin.Enabled = false;

                    }
                    catch (Exception ex)
                    {

                        var exType = ex.GetType();
                        if (exType.Name == nameof(CreatingDuplicateException))
                        {
                            MessageBox.Show($"Duplicate Data", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    fingerBox.Image = null;
                    AppExtensions.SelectedId = verifyFingerPrintRequest.Id;

                    MessageBox.Show($"Please wait while we update your patient data", "Pro-Med. Comprehensive Management Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error, please register again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ShowHintInfo("Error, please register again.");

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async void OnCapture(object sender, IZKFPEngXEvents_OnCaptureEvent e)
        {
            try
            {
                string template = ZkFprint.EncodeTemplate1(e.aTemplate);
                dynamic dynamicObject = new object();
                var user = AppExtensions.FetchUserResponse;
                var userToVerify = AppExtensions.LoginRequest;

                if (ZkFprint.VerFingerFromStr(ref template, userToVerify.ImageTemplate, false, ref Check))
                {
                    AppExtensions.SelectedId = user.Id;

                    updateVerifiedRequest.Id = user.Id;
                    updateVerifiedRequest.CheckInPatientId = user.Id;
                    updateVerifiedRequest.IsFingerVerified = true;

                    try
                    {
                        ShowHintInfo("Please wait while we validate your credentials ..");
                        await Task.Delay(2000);
                        Hide();
                        WindowState = FormWindowState.Minimized;
                        Enabled = false;

                        await browserManager.LoginUser(userToVerify);
                        //WindowState = FormWindowState.Minimized;
                        Close();

                        //InvokeHMIS(userToVerify);

                        //if (await InvokeHMIS(userToVerify) != true)
                        //{
                        //    ShowHintInfo($"User Authentication failed. \nPlease check your login details");
                        //    MessageBox.Show($"Failed");
                        //    return;
                        //}
                        //else
                        //{
                        //    fingerBox.Image = null;
                        //    buttonLogin.Enabled = false;
                        //    MessageBox.Show($"Success");
                        //    ShowHintInfo("Authentication Successful !!");

                        //}

                        //ShowHintInfo("Please wait while we validate your credentials ..");
                        //if (NotifyVerified(userToVerify).Result.Successful != true)
                        //{
                        //    ShowHintInfo($"User Authentication failed. \nPlease check your login details");
                        //    MessageBox.Show($"Failed");
                        //    return;
                        //}
                        //else
                        //{
                        //    MessageBox.Show($"Success");

                        //    //

                        //    //Application.Exit();
                        //}


                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

                else
                    ShowHintInfo("Not Verified");

            }
            catch (Exception)
            {

                throw;
            }

        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                await browserManager.CreateNewPage();
                
                StringBuilder stringBuilder = new StringBuilder();
                string username = textBoxUsername.Text;
                string usernamePattern = @"^(?!_)(?!.*\d)[A-Za-z0-9!@#$%^&*()-+=<>?/\[\]{}|~.`]+(?<!\s).{3,}$";

                string password = maskedTextBoxPassword.Text;
                string passwordPattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*()-+=<>?/\[\]{}|~.`])[^ \t\r\n\v\f]{8,}$";


                if (string.IsNullOrEmpty(textBoxUsername.Text) || string.IsNullOrEmpty(maskedTextBoxPassword.Text))
                {
                    MessageBox.Show("Username and password are required.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!Regex.IsMatch(textBoxUsername.Text, usernamePattern))
                {
                    string errorMessage = "Username must meet the following:";
                    string caption = string.Empty;
                    stringBuilder.AppendLine(errorMessage);

                    if (textBoxUsername.Text.Length < 3)
                    {
                        caption = ". Must be at least 3 characters";
                        errorMessage += $"\n{caption}";
                        stringBuilder.AppendLine($"\n{caption}");
                    }

                    if (textBoxUsername.Text.StartsWith("_"))
                    {
                        caption += ". Must not start with an underscore";
                        errorMessage += $"\n{caption}";
                    }

                    if (textBoxUsername.Text.StartsWith("0") || char.IsDigit(textBoxUsername.Text[0]))
                    {
                        caption += ". Must not start with a number";
                        errorMessage += $"\n{caption}";
                    }

                    if (Regex.IsMatch(textBoxUsername.Text, @"[^A-Za-z0-9]"))
                    {
                        caption += ". Must not contain special characters";
                        errorMessage += $"\n{caption}";
                    }

                    if (textBoxUsername.Text.Contains(" "))
                    {
                        caption += ". Must not contain whitespaces";
                        errorMessage += $"\n{caption}";
                    }

                    CustomDialog customDialog = new CustomDialog("Username must meet the following:", caption);
                    customDialog.Text = "Invalid Input";
                    customDialog.Text = "Invalid Input";
                    customDialog.ShowDialog();
                    return;

                }

                if (!Regex.IsMatch(maskedTextBoxPassword.Text, passwordPattern))
                {
                    //MessageBox.Show($"Password must meet the following: " +
                    //    $"\n.At least 8 characters " +
                    //    $"\n.One English alphabetical letter " +
                    //    $"\n.One number \n.One Special character " +
                    //    $"\n.Must not contain whitespaces", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                }

                string hashedPassword = password.HashPassword();

                FetchUserRequest fetchUserRequest = new FetchUserRequest
                {
                    Username = textBoxUsername.Text,
                    Password = maskedTextBoxPassword.Text
                };

                var response = await serviceManager.UserService.SQLFindByLoginCredentials(fetchUserRequest);
                if (!response.Successful == true)
                {
                    MessageBox.Show($"Invalid username and or passowrd. ");
                }
                else
                {
                    AppExtensions.FetchUserResponse = response.Datas[0];
                    VerifyFingerPrintRequest verifyFingerPrintRequest = new VerifyFingerPrintRequest
                    {
                        Id = response.Datas[0].Id,
                        Username = response.Datas[0].Username,
                        Password = response.Datas[0].Password,
                        ImageTemplate = AppExtensions.FetchUserResponse.ImageTemplate,
                    };

                    LoginRequest loginRequest = new LoginRequest
                    {
                        UserId = response.Datas[0].Id,
                        PowerAppShell = response.Datas[0].Id,
                        Username = response.Datas[0].Username,
                        Ssd = response.Datas[0].Id,
                        Password = response.Datas[0].Password,
                        ImageTemplate = AppExtensions.FetchUserResponse.ImageTemplate,
                    };

                    AppExtensions.CTO = string.Concat(AppExtensions.RandomString(), AppExtensions.RandomString()); 
                    AppExtensions.LoginRequest = loginRequest;

                    
                    PromptForFingerPrint();

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private async void PromptForFingerPrint()
        {
            try
            {
                if (!await CheckDeviceConnection() == true)
                    return;

                if (ZkFprint.IsRegister)
                {
                    ZkFprint.CancelEnroll();
                }
                ZkFprint.OnCapture += OnCapture;
                ZkFprint.BeginCapture();
                ShowHintInfo("Please give fingerprint sample.");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async void InvokeHMIS(LoginRequest loginRequest)
        {
            try
            {
                await authApiClient.InvokeHMIS(loginRequest);
                ShowHintInfo($"Authentication successful.");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ApiResponse<bool>> NotifyVerified(LoginRequest loginRequest)
        {
            try
            {
                var response = new ApiResponse<bool>();
                response = await authApiClient.NotifyVerified(loginRequest);
                if (!response.Successful == true)
                {

                }

                return response;
            }
            catch (Exception) 
            {

                throw;
            }
        }

        private void labelLoginCaption_Click(object sender, EventArgs e)
        {

        }

        private void labelPassword_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppExtensions.ReturnToMain();
        }

        private void goBackToolStripMenuItemLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 form1 = new Form1(serviceManager, authApiClient);
                form1.Show();
                Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void ShowHintInfo(String info)
        {
            labelPromt.Text = info;
        }

        private async Task<bool> CheckDeviceConnection()
        {
            try
            {
                if (AppExtensions.DeviceConnected != 1)
                {

                    buttonLogin.Enabled = false;
                    ShowHintInfo("Please confirm device connection. \nClose the application, connect device, then start the application.");

                    return false;

                }
                else
                {
                    buttonLogin.Enabled = true;
                }

                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}
