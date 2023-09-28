using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxZKFPEngXControl;
using zk4500.Abstractions.Interfaces;
using zk4500.Extensions;
using zk4500.Forms;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;

namespace zk4500
{
    public partial class Form1 : Form
    {
        private AxZKFPEngX ZkFprint = new AxZKFPEngX();
        private readonly IServiceManager serviceManager;

        RegisterFingerPrintRequest registerFingerPrintRequest = new RegisterFingerPrintRequest();
        RegisterFingerPrintResponse registerFingerPrintResponse = new RegisterFingerPrintResponse();
        private string[] filterOptions = { "Patient ID", "First Name", "Middle Name", "Last Name", "IP/OP Number", "ID Number", "Phone Number" };
        FetchPatientRequest fetchPatientRequest = new FetchPatientRequest();
        FetchPatientForVerificationRequest fetchPatientForVerification = new FetchPatientForVerificationRequest();
        List<FetchPatientResponse> fetchPatientResponse = new List<FetchPatientResponse>();
        List<RegisterFingerPrintRequest> registerFingerPrintRequests = new List<RegisterFingerPrintRequest>();
        List<RegisterFingerPrintResponse> registerFingerPrintResponseList = new List<RegisterFingerPrintResponse>();
        List<FetchPatientForVerificationRequest> patientsForVerificationRequestList = new List<FetchPatientForVerificationRequest>();
        List<FetchPatientForVerificationResponse> patientsForVerificationResponseList = new List<FetchPatientForVerificationResponse>();

        IEnumerable<dynamic> gridData = new List<dynamic>();

        private bool Check;

        public Form1(IServiceManager ServiceManager, RegisterFingerPrintRequest RegisterFingerPrintRequest)
        {
            InitializeComponent();
            serviceManager = ServiceManager;
            registerFingerPrintRequest = RegisterFingerPrintRequest;
            comboBoxFilter.Items.AddRange(filterOptions);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            Controls.Add(ZkFprint);
            InitialAxZkfp();

            dynamic gridData = new object();
            try
            {
                if (AppExtensions.DepartmentId == 1)
                {
                    btnVerify.Visible = false;
                    btnVerify.Enabled = false;
                    //btnRegister.Enabled = false;

                    fetchPatientResponse = await serviceManager.PatientService.SQLFindAll();
                    gridData = fetchPatientResponse;

                }
                else
                {
                    btnRegister.Visible = false;
                    btnRegister.Enabled = false;
                    btnVerify.Enabled = false;

                    patientsForVerificationResponseList = await serviceManager.FingerPrintService.SQLFetchPatientsForVerification();
                    gridData = patientsForVerificationResponseList;
                    AppExtensions.PatientsForVerificationList = patientsForVerificationResponseList;
                }



                if (gridData.Count > 0)
                {
                    UpdateGrid(gridData);
                }
                else
                {
                    MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
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
                ZkFprint.OnEnroll += zkFprint_OnEnroll;

                if (ZkFprint.InitEngine() == 0)
                {
                    ZkFprint.FPEngineVersion = "9";
                    ZkFprint.EnrollCount = 3;
                    
                    ShowHintInfo("Device successfully connected");
                }

            }
            catch(Exception ex)
            {
                ShowHintInfo("Device init err, error: " + ex.Message);
            }
        }

        public void UpdateGrid(IEnumerable<dynamic> fetchPatientResponse)
        {
            BindingList<dynamic> bindingList = new BindingList<dynamic>(fetchPatientResponse.ToList());
            registeredPatientsGridView.DataSource = bindingList;
            registeredPatientsGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            registeredPatientsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            registeredPatientsGridView.CellMouseDown += DataGridViewCellMouseDownEventHandler;
        }

        private void DataGridViewCellMouseDownEventHandler(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnRegister.Enabled = true;
            btnVerify.Enabled = true;
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Check if the Ctrl key is pressed.
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        // Clear the selection of additional rows.
                        DataGridViewRow clickedRow = registeredPatientsGridView.Rows[e.RowIndex];
                        foreach (DataGridViewRow row in registeredPatientsGridView.Rows)
                        {
                            if (row != clickedRow)
                            {
                                row.Selected = false;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private List<dynamic> GetSelectedPatients()
        {
            List<dynamic> selectedPatients = new List<dynamic>();

            try
            {
                foreach (DataGridViewRow row in registeredPatientsGridView.SelectedRows)
                {
                    // Get the corresponding FetchPatientResponse object from the data source.
                    dynamic patient = (dynamic)row.DataBoundItem;

                    // Add the selected patient to the list.
                    selectedPatients.Add(patient);

                    if (selectedPatients.Count > 0)
                    {
                        if (selectedPatients.Count >= 1)
                        {
                            foreach (var item in selectedPatients)
                            {
                                if (AppExtensions.HasProperty(item, "Id"))
                                    registerFingerPrintRequest.Id = item.Id;
                                if (AppExtensions.HasProperty(item, "UserId"))
                                    registerFingerPrintRequest.UserId = item.UserId;
                                if (AppExtensions.HasProperty(item, "PatientId"))
                                    registerFingerPrintRequest.PatientId = item.PatientId;
                                if (AppExtensions.HasProperty(item, "FirstName"))
                                    registerFingerPrintRequest.FirstName = item.FirstName;
                                if (AppExtensions.HasProperty(item, "MiddleName"))
                                    registerFingerPrintRequest.MiddleName = item.MiddleName;
                                if (AppExtensions.HasProperty(item, "LastName"))
                                    registerFingerPrintRequest.LastName = item.LastName;
                                if (AppExtensions.HasProperty(item, "IPOPNumber"))
                                    registerFingerPrintRequest.IPOPNumber = item.IPOPNumber;
                                if (AppExtensions.HasProperty(item, "IDNumber"))
                                    registerFingerPrintRequest.IDNumber = item.IDNumber;
                                if (AppExtensions.HasProperty(item, "PhoneNumber"))
                                    registerFingerPrintRequest.PhoneNumber = item.PhoneNumber;

                                registerFingerPrintRequest.Image = string.Empty;
                                registerFingerPrintRequest.ImageData = null;
                                registerFingerPrintRequest.ImageType = string.Empty;

                                registerFingerPrintRequests.Add(registerFingerPrintRequest);
                            }

                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return selectedPatients;
        }

        public async Task<List<FetchPatientResponse>> FetchData()
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

        public async Task<List<FetchPatientResponse>> FetchFilteredData(FetchPatientRequest fetchPatientRequest)
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

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            //IEnumerable<dynamic> gridData = new List<dynamic>();

            try
            {
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

                switch (selectedFilter)
                {
                    case "Patient ID":
                        if (AppExtensions.DepartmentId == 1)
                        {
                            fetchPatientRequest.Id = int.Parse(searchValue);
                            fetchPatientResponse = await FetchFilteredData(fetchPatientRequest);
                            gridData = fetchPatientResponse;
                        }
                        else
                        {
                            gridData = patientsForVerificationResponseList.Where(p => p.Id == registerFingerPrintRequest.PatientId);
                        }

                        if (gridData.Count() <= 0)
                            MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            UpdateGrid(gridData);

                        break;

                    case "IP/OP Number":
                        if (AppExtensions.DepartmentId == 1)
                        {
                            fetchPatientRequest.IPOPNumber = searchValue;
                            fetchPatientResponse = await FetchFilteredData(fetchPatientRequest);
                            gridData = fetchPatientResponse;
                        }
                        else
                        {
                            gridData = patientsForVerificationResponseList.Where(p => p.IPOPNumber == searchValue);
                        }

                        if (gridData.Count() <= 0)
                            MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            UpdateGrid(gridData);

                        break;

                    case "First Name":
                        if (AppExtensions.DepartmentId == 1)
                        {
                            fetchPatientRequest.FirstName = searchValue;
                            fetchPatientResponse = await FetchFilteredData(fetchPatientRequest);
                            gridData = fetchPatientResponse;
                        }
                        else
                        {

                        }

                        if (gridData.Count() <= 0)
                            MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            UpdateGrid(gridData);

                        break;

                    case "Middle Name":
                        if (AppExtensions.DepartmentId == 1)
                        {
                            fetchPatientRequest.MiddleName = searchValue;
                            fetchPatientResponse = await FetchFilteredData(fetchPatientRequest);
                            gridData = fetchPatientResponse;
                        }
                        else
                        {

                        }

                        if (gridData.Count() <= 0)
                            MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            UpdateGrid(gridData);

                        break;

                    case "Last Name":
                        if (AppExtensions.DepartmentId == 1)
                        {
                            fetchPatientRequest.LastName = searchValue;
                            fetchPatientResponse = await FetchFilteredData(fetchPatientRequest);
                            gridData = fetchPatientResponse;
                        }
                        else
                        {

                        }

                        if (gridData.Count() <= 0)
                            MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            UpdateGrid(gridData);

                        break;

                    case "ID Number":
                        if (AppExtensions.DepartmentId == 1)
                        {
                            fetchPatientRequest.IDNumber = searchValue;
                            fetchPatientResponse = await FetchFilteredData(fetchPatientRequest);
                            gridData = fetchPatientResponse;
                        }
                        else
                        {

                        }

                        if (gridData.Count() <= 0)
                            MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            UpdateGrid(gridData);

                        break;


                    default:
                        MessageBox.Show("Unsupported filter option selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
            catch (Exception ex)
            {

                throw;
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
                        registerFingerPrintRequest.Image = template;
                        registerFingerPrintRequest.ImageType = "bmp";
                        SaveToDB();

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    btnRegister.Enabled = false;
                    btnVerify.Enabled = true;
                    searchRichTextBox.Text = string.Empty;
                    
                    ShowHintInfo("Registration successful");
                    MessageBox.Show("Registration successful.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(sender, new EventArgs());

                    AppExtensions.SelectedId = registerFingerPrintRequest.Id;
                    await RefreshGrid(AppExtensions.SelectedId);



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

        private async void zkFprint_OnCapture(object sender, IZKFPEngXEvents_OnCaptureEvent e)
        {
            try
            {
                string template = ZkFprint.EncodeTemplate1(e.aTemplate);

                var selectedPatients = GetSelectedPatients();
                var patientsToVerify = await serviceManager.FingerPrintService.SQLFindAll();
                var patientToVerify = patientsToVerify.Where(p => p.Id == registerFingerPrintRequest.Id).FirstOrDefault() ?? new FetchFingerPrintResponse();

                if (ZkFprint.VerFingerFromStr(ref template, patientToVerify.ImageTemplate, false, ref Check))
                {
                    ShowHintInfo("Verified");

                    AppExtensions.SelectedId = patientToVerify.Id;
                    await RefreshGrid(AppExtensions.SelectedId);
                }

                else
                    ShowHintInfo("Not Verified");
                    AppExtensions.SelectedId = patientToVerify.Id;
                    await RefreshGrid(AppExtensions.SelectedId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async Task RefreshGrid(dynamic param)
        {
            IEnumerable<dynamic> newGridData = new List<dynamic>();
            if (AppExtensions.DepartmentId == 1)
            {
                newGridData = await FetchData();
            }
            else
            {
                newGridData = await serviceManager.FingerPrintService.SQLFetchPatientsForVerification();
            }
            
            var gridData = newGridData.Where(r => r.Id != param);
            UpdateGrid(gridData);
        }

        private void ShowHintInfo(String s)
        {
              prompt.Text = s;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                if (ZkFprint.IsRegister)
                {
                    ZkFprint.CancelEnroll();
                }
                ZkFprint.OnCapture += zkFprint_OnCapture;
                ZkFprint.BeginCapture();
                ShowHintInfo("Please give fingerprint sample.");
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedPatient = GetSelectedPatients();

                ZkFprint.CancelEnroll();
                ZkFprint.EnrollCount = 3;
                ZkFprint.BeginEnroll();
                ShowHintInfo("Please give fingerprint sample.");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            fpicture.Image = null;
            //txtTemplate.Text = string.Empty;
        }

        private void prompt_Click(object sender, EventArgs e)
        {

        }

        private async void SaveToDB()
        {
            await serviceManager.FingerPrintService.SQLCreate(registerFingerPrintRequest);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
