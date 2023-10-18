using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxZKFPEngXControl;
using zk4500.Abstractions.Interfaces;
using zk4500.ApiClient;
using zk4500.Exceptions;
using zk4500.Extensions;
using zk4500.Forms;
using zk4500.Helpers.BrowserHelpers;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;
using Timer = System.Windows.Forms.Timer;

namespace zk4500
{
    public partial class Form1 : Form
    {
        private AxZKFPEngX ZkFprint = new AxZKFPEngX();
        private readonly IServiceManager serviceManager;
        private readonly IAuthApiClient authApiClient;
        private Timer exitTimer;

        RegisterFingerPrintRequest registerFingerPrintRequest = new RegisterFingerPrintRequest();
        RegisterFingerPrintResponse registerFingerPrintResponse = new RegisterFingerPrintResponse();

        UpdateVerifiedRequest updateVerifiedRequest = new UpdateVerifiedRequest();
        UpdateVerifiedResponse updateVerifiedResponse = new UpdateVerifiedResponse();

        FetchPatientRequest fetchPatientRequest = new FetchPatientRequest();
        List<FetchPatientResponse> fetchPatientsResponse = new List<FetchPatientResponse>();

        FetchUserResponse fetchUserResponse = new FetchUserResponse();
        List<FetchUserResponse> fetchUsersResponse = new List<FetchUserResponse>();

        FetchPatientForVerificationRequest fetchPatientForVerification = new FetchPatientForVerificationRequest();

        List<RegisterFingerPrintRequest> registerFingerPrintRequests = new List<RegisterFingerPrintRequest>();
        List<RegisterFingerPrintResponse> registerFingerPrintResponseList = new List<RegisterFingerPrintResponse>();

        List<FetchPatientForVerificationRequest> patientsForVerificationRequestList = new List<FetchPatientForVerificationRequest>();
        List<FetchPatientForVerificationResponse> patientsForVerificationResponseList = new List<FetchPatientForVerificationResponse>();

        private string[] filterOptions = { };
        IEnumerable<dynamic> gridData = new List<dynamic>();
        private Timer timer = new Timer();
        private bool Check;
        private string Message;

        private BrowserManager browserManager;

        public Form1(IServiceManager ServiceManager, IAuthApiClient AuthApiClient)
        {
            InitializeComponent();
            serviceManager = ServiceManager;
            authApiClient = AuthApiClient;

            timer.Interval = int.MaxValue;
            timer.Tick += Timer_Tick;

            browserManager = new BrowserManager();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            Controls.Add(ZkFprint);
            InitialAxZkfp();
            ControlBox = true;

            labelMessage.Visible = false;

            btnRegister.Enabled = false;
            btnRegister.Visible = true;

            btnVerify.Enabled = false;
            btnVerify.Visible = false;

            goBackToolStripMenuItemForm1.Alignment = ToolStripItemAlignment.Right;
            exitToolStripMenuItemForm1.Alignment = ToolStripItemAlignment.Right;
            

            HideFormElements();
            //await PopulateGrid();

            await browserManager.Initialize();
        }

        private async Task PopulateGrid()
        {
            dynamic gridData = new object();
            try
            {
                if (AppExtensions.DepartmentId == 14)
                {
                    switch (AppExtensions.GridRefreshed)
                    {
                        case 1:
                            btnRegister.Enabled = true; break;
                        default:
                            break;
                    }

                    AppExtensions.CaptureAction = 1;
                    btnVerify.Visible = false;
                    btnVerify.Enabled = false;

                    switch (AppExtensions.IsPatient)
                    {
                        case true:
                            fetchPatientsResponse = await serviceManager.PatientService.SQLFindAll();
                            gridData = fetchPatientsResponse;
                            break;

                        case false:
                            fetchUsersResponse = await serviceManager.UserService.SQLFindAll();
                            gridData = fetchUsersResponse;
                            break;

                        default:
                            break;
                    }

                }
                else
                {
                    switch (AppExtensions.GridRefreshed)
                    {
                        case 1:
                            btnVerify.Enabled = true; break;
                        default:
                            break;
                    }

                    AppExtensions.CaptureAction = 2;

                    patientsForVerificationResponseList = await serviceManager.PatientService.SQLFetchPatientsForVerification();

                    gridData = patientsForVerificationResponseList;

                    AppExtensions.PatientsForVerificationList = patientsForVerificationResponseList;
                }

                if (gridData.Count > 0)
                {
                    UpdateGrid(gridData);
                    var selectedPatients = GetSelectedPatients();
                    if (selectedPatients.Any())
                    {
                        if (selectedPatients.Count > 1)
                        {
                            ShowHintInfo($"Capturing multiple fingerprints is not allowed. Please select one item");
                            return;
                        }
                        else
                        {
                            foreach (var item in selectedPatients)
                            {
                                labelMessage.Visible = true;
                                labelMessage.Text = string.Empty;
                                string numberText = $"- IP/OP Number : {item.IPOPNumber}";

                                switch (AppExtensions.IsPatient)
                                {
                                    case false:
                                        numberText = string.Empty;
                                        break;

                                    default:
                                        break;
                                }

                                switch (AppExtensions.CaptureAction)
                                {
                                    case 1:
                                        ShowCustomMessage($"Capture fingerprint for {item.FirstName} {item.MiddleName} {item.LastName} {numberText}");
                                        ShowHintInfo(string.Empty);
                                        break;

                                    default:
                                        ShowCustomMessage($"Verifying fingerprint for {item.FirstName} {item.MiddleName} {item.LastName} {numberText}");
                                        ShowHintInfo(string.Empty);
                                        break;
                                }

                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void InitialAxZkfp()
        {
            try
            {

                ZkFprint.OnImageReceived += zkFprint_OnImageReceived;
                ZkFprint.OnFeatureInfo += zkFprint_OnFeatureInfo;
                //zkFprint.OnFingerTouching 
                //zkFprint.OnFingerLeaving
                ZkFprint.OnEnroll += zkFprint_OnEnroll;

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

        private void zkFprint_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            try
            {
                Graphics g = fpicture.CreateGraphics();
                Bitmap bmp = new Bitmap(fpicture.Width, fpicture.Height);
                g = Graphics.FromImage(bmp);
                int dc = g.GetHdc().ToInt32();
                ZkFprint.PrintImageAt(dc, 0, 0, bmp.Width, bmp.Height);
                g.Dispose();
                fpicture.Image = bmp;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void zkFprint_OnFeatureInfo(object sender, IZKFPEngXEvents_OnFeatureInfoEvent e)
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

        private async void zkFprint_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            try
            {
                if (e.actionResult)
                {
                    string template = ZkFprint.EncodeTemplate1(e.aTemplate);

                    try
                    {
                        registerFingerPrintRequest.Id = AppExtensions.PatientId;
                        registerFingerPrintRequest.Image = template;
                        registerFingerPrintRequest.ImageType = "bmp";
                        await SaveFingerPrintToDB(registerFingerPrintRequest);
                        btnRegister.Enabled = false;

                    }
                    catch (Exception ex)
                    {
                        // Get the corresponding FetchPatientResponse object from the data source.
                        //dynamic patient = (dynamic)row.DataBoundItem;

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

                    btnClear_Click(sender, new EventArgs());
                    AppExtensions.SelectedId = registerFingerPrintRequest.Id;

                    MessageBox.Show($"Please wait while we update your data", "Pro-Med. Comprehensive Management Solutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowCustomMessage("Updating your data..." +
                    "\n  Pro-Med. Comprehensive Management Solutions");

                    await BeginRefreshGrid(AppExtensions.SelectedId);
                    //InitialAxZkfp();

                }
                else
                {
                    MessageBox.Show("Error, please register again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ShowHintInfo("Error, please register again.");
                    btnClear_Click(new object(), new EventArgs());

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async void zkFprint_OnCapture(object sender, IZKFPEngXEvents_OnCaptureEvent e)
        {
            try
            {
                string template = ZkFprint.EncodeTemplate1(e.aTemplate);

                dynamic patientToVerify = new object();
                if (AppExtensions.DepartmentId != 14)
                {
                    patientToVerify = new FetchPatientForVerificationResponse();
                }
                else
                {
                    patientToVerify = new FetchPatientResponse();
                }

                var selectedPatients = GetSelectedPatients();
                if (selectedPatients.Count > 1)
                    foreach (var item in selectedPatients)
                    {
                        var patientsToVerify = item;
                        labelMessage.Visible = true;
                        ShowCustomMessage($"Verifying fingerprint for {item.FirstName} {item.MiddleName} {item.LastName} - IP/OP Number : {item.IPOPNumber}");
                    }
                else
                {
                    patientToVerify = selectedPatients.FirstOrDefault();
                    //patientToVerify = selectedPatients.Where(p => p.Id == AppExtensions.PatientId).FirstOrDefault();
                }

                if (ZkFprint.VerFingerFromStr(ref template, patientToVerify.ImageTemplate, false, ref Check))
                {
                    AppExtensions.SelectedId = patientToVerify.Id;
                    await RefreshGrid(AppExtensions.SelectedId);

                    updateVerifiedRequest.Id = patientToVerify.Id;
                    updateVerifiedRequest.CheckInPatientId = patientToVerify.CheckInID;
                    updateVerifiedRequest.IsFingerVerified = true;

                    await UpdateVerified(updateVerifiedRequest);

                    if (AppExtensions.UpdateQueryResult <= 0)
                        ShowHintInfo("Data Store Update Error");
                    else
                        ShowHintInfo("Verified");
                    ShowCustomMessage(string.Empty);
                    fpicture.Image = null;
                    btnVerify.Enabled = false;
                }

                else
                    ShowHintInfo("Not Verified");

            }
            catch (Exception)
            {

                throw;
            }

        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!await CheckDeviceConnection() == true)
                    return;

                if (registeredPatientsGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a patient to proceed.", "No Item Selected.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ZkFprint.CancelEnroll();
                    ZkFprint.EnrollCount = 3;
                    ZkFprint.BeginEnroll();
                    ShowHintInfo("Please give fingerprint sample.");
                    btnRegister.Enabled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            //return selectedPatients;
        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                if (!await CheckDeviceConnection() == true)
                    return;

                if (registeredPatientsGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a patient to proceed.", "No Item Selected.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (ZkFprint.IsRegister)
                    {
                        ZkFprint.CancelEnroll();
                    }

                    ZkFprint.OnCapture += zkFprint_OnCapture;
                    ZkFprint.BeginCapture();
                    ShowHintInfo("Please give fingerprint sample.");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            fpicture.Image = null;
        }

        private void prompt_Click(object sender, EventArgs e)
        {

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<dynamic> gridData = new List<dynamic>();
                fetchPatientRequest = new FetchPatientRequest();
                var fetchPatientResponseList = new List<FetchPatientResponse>();
                if (comboBoxFilter.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a filter option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(searchRichTextBox.Text))
                {
                    MessageBox.Show("Please enter a search value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string selectedFilter = comboBoxFilter.SelectedItem.ToString();
                string searchValue = searchRichTextBox.Text;
                searchValue = searchValue.Replace(" ", "");
                StringBuilder sb = new StringBuilder();

                try
                {
                    switch (selectedFilter)
                    {
                        case "Patient ID":
                            fetchPatientRequest.Id = int.Parse(searchValue); break;

                        case "IP/OP Number":
                            fetchPatientRequest.IPOPNumber = searchValue; break;

                        case "Username":
                            fetchPatientRequest.Username = searchValue; break;

                        case "Name":
                            fetchPatientRequest.FullName = searchValue; break;

                        case "First Name":
                            fetchPatientRequest.FirstName = searchValue; break;

                        case "Middle Name":
                            fetchPatientRequest.MiddleName = searchValue; break;

                        case "Last Name":
                            fetchPatientRequest.LastName = searchValue; break;

                        case "Phone Number":
                            fetchPatientRequest.PhoneNumber = searchValue; break;

                        case "ID Number":
                            fetchPatientRequest.IDNumber = searchValue; break;

                        default:
                            MessageBox.Show("Unsupported filter option selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                    }

                    switch (AppExtensions.IsPatient)
                    {
                        case true:
                            fetchPatientsResponse = await FetchFilteredPatients(fetchPatientRequest) ?? new List<FetchPatientResponse>();
                            gridData = fetchPatientsResponse;
                            break;

                        case false:
                            var request = new Shared.Dtos.Request
                            {
                                Username = fetchPatientRequest.Username,
                                FullName = fetchPatientRequest.FullName,
                                FirstName = fetchPatientRequest.FirstName,
                                MiddleName = fetchPatientRequest.MiddleName,
                                LastName = fetchPatientRequest.LastName

                            };

                            fetchUsersResponse = await FetchFilteredUsers(request) ?? new List<FetchUserResponse>();
                            gridData = fetchUsersResponse;
                            break;

                        default:
                            break;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Switch error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }

                if (gridData.Count() <= 0)
                    MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    UpdateGrid(gridData);

                DisplayActionMessages();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured during patient search. {ex.Message} \n Please contact system admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }

        }

        private async void btnExit_Click(object sender, EventArgs e)
        {
            fetchPatientRequest = new FetchPatientRequest();
            searchRichTextBox.Clear();
            comboBoxFilter.SelectedIndex = -1;
            await PopulateGrid();
            AppExtensions.GridRefreshed = 1;

        }

        public void UpdateGrid(IEnumerable<dynamic> fetchPatientResponse)
        {
            try
            {
                BindingList<dynamic> bindingList = new BindingList<dynamic>(fetchPatientResponse.ToList());
                registeredPatientsGridView.DataSource = bindingList;

                DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                headerStyle.Font = new Font(registeredPatientsGridView.Font, FontStyle.Bold);
                headerStyle.BackColor = Color.FromArgb(100, 151, 177);
                headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                registeredPatientsGridView.AllowUserToAddRows = false;
                registeredPatientsGridView.ColumnHeadersDefaultCellStyle = headerStyle;
                registeredPatientsGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                registeredPatientsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                registeredPatientsGridView.CellMouseDown += DataGridViewCellMouseDownEventHandler;

                AppExtensions.ManageGridColumns(registeredPatientsGridView);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void DataGridViewCellMouseDownEventHandler(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnRegister.Enabled = true;
            btnVerify.Enabled = true;

            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 || e.ColumnIndex <= 0)
                {
                    // Clear the selection for all rows.
                    foreach (DataGridViewRow row in registeredPatientsGridView.Rows)
                    {
                        row.Selected = false;
                    }

                    // Select the clicked row.
                    registeredPatientsGridView.Rows[e.RowIndex].Selected = true;
                }

                var selectedPatients = GetSelectedPatients();
                if (selectedPatients.Any())
                {
                    if (selectedPatients.Count > 1)
                    {
                        ShowHintInfo($"Capturing multiple fingerprints is not allowed. Please select one item");
                        return;
                    }
                    else
                    {
                        var selectedPateint = selectedPatients.FirstOrDefault();
                        labelMessage.Visible = true;
                        labelMessage.Text = string.Empty;

                        AppExtensions.PatientId = selectedPateint.Id;
                        ShowActionMessage(selectedPateint);


                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnInitializeDevice_Click(object sender, EventArgs e)
        {
            try
            {
                InitialAxZkfp();
                btnRegister.Enabled = true;
                btnVerify.Enabled = true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<FetchPatientResponse>> FetchData() //FetchUserData
        {
            try
            {
                var response = await serviceManager.PatientService.SQLFindAll();
                if (response.Count <= 0)
                {
                    return response;
                }

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<FetchUserResponse>> FetchUserData()
        {
            try
            {
                var response = await serviceManager.UserService.SQLFindAll();
                if (response.Count <= 0)
                {
                    return response;
                }

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<FetchPatientResponse>> FetchPatientData()
        {
            try
            {
                var response = await serviceManager.PatientService.SQLFindAll();
                if (response.Count <= 0)
                {
                    return response;
                }

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<FetchPatientResponse>> FetchFilteredPatients(FetchPatientRequest fetchPatientRequest)
        {
            try
            {
                var response = await serviceManager.PatientService.SQLFindByCondition(fetchPatientRequest);
                if (!response.Successful == true)
                {
                    return response.Datas;
                }

                return response.Datas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<FetchUserResponse>> FetchFilteredUsers(Shared.Dtos.Request request)
        {
            try
            {
                var fetchUserRequest = new FetchUserRequest
                {
                    Id = request.Id,
                    Username = request.Username,
                    Password = request.Password,
                    FullName = request.FullName,
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName,
                };

                var response = await serviceManager.UserService.SQLFindByCondition(fetchUserRequest);
                if (!response.Successful == true)
                {
                    return response.Datas;
                }

                return response.Datas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DisplayActionMessages()
        {
            try
            {
                var selectedPatients = GetSelectedPatients();
                if (selectedPatients.Any())
                {
                    if (selectedPatients.Count == 1)
                    {
                        labelMessage.Visible = true;
                        labelMessage.Text = string.Empty;
                        ShowActionMessage(selectedPatients[0]);
                    }
                    else if (selectedPatients.Count > 1)
                    {
                        ShowForbiddenActionMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            //ShowHintInfo(strTemp);
        }

        private List<dynamic> GetSelectedPatients()
        {
            List<dynamic> selectedPatients = new List<dynamic>();

            try
            {
                foreach (DataGridViewRow row in registeredPatientsGridView.SelectedRows)
                {
                    // Get the corresponding FetchPatientResponse object from the data source.
                    dynamic patient = row.DataBoundItem;
                    AppExtensions.PatientId = patient.Id;
                    selectedPatients.Add(patient);

                    if (selectedPatients.Count == 1)
                    {
                        RegisterFingerPrintRequest registerFingerPrintRequest = new RegisterFingerPrintRequest();
                        if (AppExtensions.HasProperty(patient, "Id"))
                            registerFingerPrintRequest.Id = patient.Id;
                        if (AppExtensions.HasProperty(patient, "UserId"))
                            registerFingerPrintRequest.UserId = patient.UserId;
                        if (AppExtensions.HasProperty(patient, "PatientId"))
                            registerFingerPrintRequest.PatientId = patient.PatientId;
                        if (AppExtensions.HasProperty(patient, "FirstName"))
                            registerFingerPrintRequest.FirstName = patient.FirstName;
                        if (AppExtensions.HasProperty(patient, "MiddleName"))
                            registerFingerPrintRequest.MiddleName = patient.MiddleName;
                        if (AppExtensions.HasProperty(patient, "LastName"))
                            registerFingerPrintRequest.LastName = patient.LastName;
                        if (AppExtensions.HasProperty(patient, "IPOPNumber"))
                            registerFingerPrintRequest.IPOPNumber = patient.IPOPNumber;
                        if (AppExtensions.HasProperty(patient, "IDNumber"))
                            registerFingerPrintRequest.IDNumber = patient.IDNumber;
                        if (AppExtensions.HasProperty(patient, "PhoneNumber"))
                            registerFingerPrintRequest.PhoneNumber = patient.PhoneNumber;

                        registerFingerPrintRequest.Image = patient.ImageTemplate;
                        registerFingerPrintRequest.ImageData = null;
                        registerFingerPrintRequest.ImageType = string.Empty;

                        registerFingerPrintRequests.Add(registerFingerPrintRequest);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {nameof(GetSelectedPatients)} - {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return selectedPatients;
        }

        private void ShowActionMessage(dynamic item)
        {
            try
            {
                string numberText = $"- IP/OP Number : {item.IPOPNumber}";
                switch (AppExtensions.IsPatient)
                {
                    case false:
                        numberText = string.Empty;
                        break;

                    default:
                        break;
                }

                switch (AppExtensions.CaptureAction)
                {

                    case 1:
                        ShowCustomMessage($"Capture fingerprint for {item.FirstName} {item.MiddleName} {item.LastName} {numberText}");
                        ShowHintInfo(string.Empty);
                        btnRegister.Enabled = true;
                        break;

                    default:
                        ShowCustomMessage($"Verifying fingerprint for {item.FirstName} {item.MiddleName} {item.LastName} {numberText}");
                        ShowHintInfo(string.Empty);
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ShowForbiddenActionMessage()
        {
            try
            {
                switch (AppExtensions.CaptureAction)
                {
                    case 1:
                        ShowHintInfo($"Capturing multiple fingerprints is not allowed. Please select one item");
                        break;

                    default:
                        ShowHintInfo($"Verifying multiple fingerprints is not allowed. Please select one item");
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<UpdateVerifiedResponse> UpdateVerified(UpdateVerifiedRequest updateVerifiedRequest)
        {
            try
            {
                updateVerifiedResponse = await serviceManager.PatientService.SQLUpdateVerified(updateVerifiedRequest);
                if (!updateVerifiedResponse.IsFingerVerified == true)
                {
                    MessageBox.Show("Updating verification failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return updateVerifiedResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ShowHintInfo(String s)
        {
            prompt.Text = s;
        }

        private void ShowCustomMessage(string message)
        {
            labelMessage.Text = message;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the "Please wait" message or add animation as needed
        }

        private async Task SaveFingerPrintToDB(RegisterFingerPrintRequest registerFingerPrintRequest)
        {
            try
            {
                btnRegister.Enabled = false;
                btnVerify.Enabled = true;
                searchRichTextBox.Clear();
                comboBoxFilter.SelectedIndex = -1;

                switch (AppExtensions.IsPatient)
                {
                    case false:
                        registerFingerPrintRequest.EntityType = 2;
                        break;

                    default:
                        break;
                }

                await serviceManager.FingerPrintService.SQLCreate(registerFingerPrintRequest);


                ShowHintInfo("Registration successful !!");

                //MessageBox.Show("Registration successful !!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception)
            {
                throw;


            }

        }

        private async Task BeginRefreshGrid(dynamic param)
        {
            DisableControls();
            timer.Start();

            try
            {
                await RefreshGrid(param);
            }
            catch (Exception)
            {
                MessageBox.Show($"Could not refresh grid at the moment. \nPlease contact system admin. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!timer.Enabled)
                    labelMessage.Visible = true;
                else
                    labelMessage.Visible = false;
                timer.Stop();
                EnableControls();
            }
        }

        private async Task RefreshGrid(dynamic param)
        {
            try
            {
                IEnumerable<dynamic> newGridData = new List<dynamic>();
                if (AppExtensions.DepartmentId == 14)
                {
                    switch (AppExtensions.IsPatient)
                    {
                        case false:
                            newGridData = await FetchUserData();
                            break;

                        case true:
                            newGridData = await FetchPatientData();
                            break;

                        default:
                            break;
                    }

                    //newGridData = await FetchData();


                }
                else
                {
                    newGridData = await serviceManager.PatientService.SQLFetchPatientsForVerification();
                }

                var gridData = newGridData.Where(r => r.Id != param) ?? new List<FetchPatientResponse>();

                if (gridData.Count() == 0)
                {
                    ShowHintInfo("Kudoz!! Nothing on your list!");
                }
                UpdateGrid(gridData);

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void DisableControls()
        {
            foreach (Control control in Controls)
            {
                control.Enabled = false;
            }
        }

        private void EnableControls()
        {
            foreach (Control control in Controls)
            {
                control.Enabled = true;
            }
        }

        private void goBackToolStripMenuItemForm1_Click(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Minimized;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void userFingerprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                filterOptions = new string[] { "Username", "Name", "Phone Number" };
                comboBoxFilter.Items.AddRange(filterOptions);
                AppExtensions.IsPatient = false;
                ShowFormElements();
                loginToolStripMenuItem.Enabled = false;
                loginToolStripMenuItem.Visible = false;
                label1.Text = "Users";
                await PopulateGrid();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void patientFingerprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                filterOptions = new string[] { "Patient ID", "First Name", "Middle Name", "Last Name", "IP/OP Number", "Phone Number" };
                comboBoxFilter.Items.AddRange(filterOptions);
                AppExtensions.IsPatient = true;
                ShowFormElements();
                loginToolStripMenuItem.Enabled = false;
                loginToolStripMenuItem.Visible = false;
                await PopulateGrid();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Login login = new Login(serviceManager, authApiClient, browserManager);

                Enabled = false;
                login.ShowDialog();
                Enabled = true;
                WindowState = FormWindowState.Minimized;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void exitToolStripMenuItemForm1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //AppExtensions.ReturnToMain();
        }

        private void HideFormElements()
        {
            try
            {
                List<string> filterParams = new List<string>()
                {
                    "btn", "button", "lbl", "label", "grid", "picture", "promp", "combo", "box"
                };

                foreach (Control control in Controls)
                {
                    foreach (string filter in filterParams)
                    {
                        if (control.Name.ToLower().Contains(filter.ToLower()) && control.Name != "labeMainCaption")
                        {
                            control.Visible = false;
                            break;
                        }
                    }
                }

                this.BackgroundImage = Image.FromFile($"D:\\Documents\\Photos\\DevRelated\\bg8.jpeg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
                labelPoweredByForm1.Visible = true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void ShowFormElements()
        {
            try
            {
                this.BackgroundImage = null;
                List<string> filterParams = new List<string>()
                {
                    "btn", "button", "lbl", "label", "grid", "picture", "prompt", "combo", "box"
                };

                foreach (Control control in Controls)
                {
                    foreach (string filter in filterParams)
                    {
                        if (control.Name.ToLower().Contains(filter.ToLower()))
                        {
                            control.Visible = true;

                            break;
                        }
                    }
                }

                labelMessage.Visible = false;
                if (AppExtensions.DepartmentId != 14)
                {
                    btnRegister.Enabled = false;
                    btnRegister.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<bool> CheckDeviceConnection()
        {
            try
            {
                if (AppExtensions.DeviceConnected != 1)
                {
                    btnRegister.Enabled = false;
                    btnVerify.Enabled = false;
                    ShowHintInfo("Please confirm device connection. \nClose the application, connect device, then start the application.");

                    return false;

                }
                else
                {
                    btnRegister.Enabled = true;
                }

                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void HandleApplicationLifetime()
        {
            try
            {
                DateTime currentTime = DateTime.Now;
                DateTime targetTime = DateTime.Today.AddHours(18);
                TimeSpan timeRemaining;

                // If the current time is already past 4 am, calculate the time remaining for the next day
                if (DateTime.Now >= targetTime)
                {
                    targetTime = targetTime.AddDays(1);
                    timeRemaining = targetTime - DateTime.Now;
                }
                else
                {
                    timeRemaining = targetTime - DateTime.Now;
                }

                if (timeRemaining.TotalMilliseconds > 0)
                {
                    // Set up the timer with the remaining time
                    exitTimer = new Timer();
                    exitTimer.Interval = (int)timeRemaining.TotalMilliseconds;
                    exitTimer.Tick += ExitApplication;
                    exitTimer.Start();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void ExitApplication(object sender, EventArgs e)
        {
            // Exit the application when the timer ticks
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void RefreshForm()
        {
            Controls.Add(ZkFprint);
            InitialAxZkfp();
            labelMessage.Visible = false;
            btnRegister.Enabled = false;
            btnRegister.Visible = true;
            btnVerify.Enabled = false;
            btnVerify.Visible = false;
            loginToolStripMenuItem.Visible = true;
            loginToolStripMenuItem.Enabled = true;
            goBackToolStripMenuItemForm1.Alignment = ToolStripItemAlignment.Right;
            exitToolStripMenuItemForm1.Alignment = ToolStripItemAlignment.Right;
            HideFormElements();
        }



    }
}
