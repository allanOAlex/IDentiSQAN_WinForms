using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using zk4500.Abstractions.Interfaces;
using zk4500.Extensions;
using zk4500.Shared.Dtos;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;

namespace zk4500.Forms
{
    public partial class RegisteredPatients : Form
    {
        private readonly IServiceManager serviceManager;


        private FlowLayoutPanel resultPanel;
        private string[] filterOptions = { "Patient ID", "First Name", "Middle Name", "Last Name", "IP/OP Number", "ID Number", "Phone Number" };
        FetchPatientRequest fetchPatientRequest = new FetchPatientRequest();
        FetchPatientForVerificationRequest fetchPatientForVerification = new FetchPatientForVerificationRequest();
        List<FetchPatientResponse> fetchPatientResponse = new List<FetchPatientResponse>();
        List<RegisterFingerPrintRequest> registerFingerPrintRequests = new List<RegisterFingerPrintRequest>();
        List<RegisterFingerPrintResponse> registerFingerPrintResponse = new List<RegisterFingerPrintResponse>();
        List<FetchPatientForVerificationRequest> patientsForVerificationRequest = new List<FetchPatientForVerificationRequest>();
        List<FetchPatientForVerificationResponse> patientsForVerificationResponse = new List<FetchPatientForVerificationResponse>();
        



        public RegisteredPatients(IServiceManager ServiceManager)
        {
            InitializeComponent();
            serviceManager = ServiceManager;
            comboBoxFilter.Items.AddRange(filterOptions);
            

        }

        private async void RegisteredPatients_Load(object sender, EventArgs e)
        {
            dynamic gridData = new object();
            try
            {
                if (AppExtensions.DepartmentId == 1  )
                {
                    fetchPatientResponse = await serviceManager.PatientService.SQLFindAll();
                    gridData = fetchPatientResponse;

                }
                else
                {
                    patientsForVerificationResponse = await serviceManager.FingerPrintService.SQLFetchPatientsForVerification();
                    gridData = patientsForVerificationResponse;
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

        public void UpdateGrid(IEnumerable<dynamic> fetchPatientResponse)
        {
            BindingList<dynamic> bindingList = new BindingList<dynamic>(fetchPatientResponse.ToList());
            registeredPatientsGridView.DataSource = bindingList;
            registeredPatientsGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            registeredPatientsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            registeredPatientsGridView.CellMouseDown += DataGridViewCellMouseDownEventHandler;
        }

        public void ShowSearchResults(List<FetchPatientResponse> filteredPatients)
        {
            PopulateResults(filteredPatients);
            //ShowDialog();
        }

        public void PopulateResults(List<FetchPatientResponse> filteredPatients)
        {
            registeredPatientsGridView.Rows.Clear();

            foreach (var patient in filteredPatients)
            {
                registeredPatientsGridView.Rows.Add(patient.Id, patient.FirstName, patient.MiddleName, patient.LastName, patient.IPOPNumber, patient.IDNumber, patient.PhoneNumber);
            }
        }

        private async void btn_FilterRegisteredPatients_Click(object sender, EventArgs e)
        {
            dynamic gridData = new object();
            var selectedPatientForVerification = GetPatientForVerification();
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
                            fetchPatientResponse = await FetchData(fetchPatientRequest);
                            gridData = fetchPatientResponse;
                        }
                        else
                        {
                            gridData = patientsForVerificationResponse.Where(p => p.Id == selectedPatientForVerification.CheckInID);
                        }
                        
                        UpdateGrid(gridData);
                        break;

                    case "IP/OP Number":
                        if (AppExtensions.DepartmentId == 1)
                        {
                            fetchPatientRequest.IPOPNumber = searchValue;
                            fetchPatientResponse = await FetchData(fetchPatientRequest);
                            gridData = fetchPatientResponse;
                        }
                        else
                        {
                            gridData = patientsForVerificationResponse.Where(p => p.IPOPNumber == selectedPatientForVerification.IPOPNumber);
                        }

                        UpdateGrid(gridData);
                        break;

                    case "First Name":
                        if (AppExtensions.DepartmentId == 1)
                        {
                            fetchPatientRequest.FirstName = searchValue;
                            fetchPatientResponse = await FetchData(fetchPatientRequest);
                            gridData = fetchPatientResponse;
                        }
                        else
                        {

                        }

                        UpdateGrid(gridData);
                        break;

                    case "Middle Name":
                        if (AppExtensions.DepartmentId == 1)
                        {
                            fetchPatientRequest.MiddleName = searchValue;
                            fetchPatientResponse = await FetchData(fetchPatientRequest);
                            gridData = fetchPatientResponse;
                        }
                        else
                        {

                        }

                        UpdateGrid(gridData);
                        break;

                    case "Last Name":
                        if (AppExtensions.DepartmentId == 1)
                        {
                            fetchPatientRequest.LastName = searchValue;
                            fetchPatientResponse = await FetchData(fetchPatientRequest);
                            gridData = fetchPatientResponse;
                        }
                        else
                        {

                        }

                        UpdateGrid(gridData);
                        break;

                    case "ID Number":
                        if (AppExtensions.DepartmentId == 1)
                        {
                            fetchPatientRequest.IDNumber = searchValue;
                            fetchPatientResponse = await FetchData(fetchPatientRequest);
                            gridData = fetchPatientResponse;
                        }
                        else
                        {

                        }

                        UpdateGrid(gridData);
                        break;


                    default:
                        MessageBox.Show("Unsupported filter option selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; 
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void registeredPatientsGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                registerFingerPrintRequests.Clear(); // Clear any previously selected patients.

                foreach (DataGridViewRow row in registeredPatientsGridView.SelectedRows)
                {
                    // Create a new SelectedPatient instance and populate it with data from the selected row.
                    RegisterFingerPrintRequest selectedPatient = new RegisterFingerPrintRequest
                    {
                        Id = (int)row.Cells["Id"].Value,
                        FirstName = row.Cells["FirstName"].Value?.ToString(),
                        MiddleName = row.Cells["MiddleName"].Value?.ToString(),
                        LastName = row.Cells["LastName"].Value?.ToString(),
                        IPOPNumber = row.Cells["IPOPNumber"].Value?.ToString(),
                        IDNumber = row.Cells["IDNumber"].Value?.ToString(),
                        PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString()
                    };

                    registerFingerPrintRequests.Add(selectedPatient);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private List<FetchPatientResponse> GetSelectedPatients()
        {
            List<FetchPatientResponse> selectedPatients = new List<FetchPatientResponse>();

            try
            {
                foreach (DataGridViewRow row in registeredPatientsGridView.SelectedRows)
                {
                    // Get the corresponding FetchPatientResponse object from the data source.
                    FetchPatientResponse patient = (FetchPatientResponse)row.DataBoundItem;

                    // Add the selected patient to the list.
                    selectedPatients.Add(patient);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            return selectedPatients;
        }

        private FetchPatientForVerificationResponse GetPatientForVerification()
        {
            FetchPatientForVerificationResponse patient = new FetchPatientForVerificationResponse();

            try
            {
                
                foreach (DataGridViewRow row in registeredPatientsGridView.SelectedRows)
                {
                    patient = (FetchPatientForVerificationResponse)row.DataBoundItem;
                    
                }
            }
            catch (Exception)
            {

                throw;
            }

            return patient;
        }

        private void DataGridViewCellMouseDownEventHandler(object sender, DataGridViewCellMouseEventArgs e)
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

        private void btn_CaptureFingerprint_Click(object sender, EventArgs e)
        {
            try
            {
                RegisterFingerPrintRequest registerFingerPrintRequest = new RegisterFingerPrintRequest();
                var selectedPatient = GetSelectedPatients();
                if (selectedPatient.Count > 0)
                {
                    if (selectedPatient.Count >= 1)
                    {
                        foreach (var item in selectedPatient)
                        {
                            registerFingerPrintRequest.Id = item.Id;
                            registerFingerPrintRequest.UserId = item.Id;
                            registerFingerPrintRequest.PatientId = item.Id;
                            registerFingerPrintRequest.FirstName = item.FirstName;
                            registerFingerPrintRequest.MiddleName = item.MiddleName;
                            registerFingerPrintRequest.LastName = item.LastName;
                            registerFingerPrintRequest.IPOPNumber = item.IPOPNumber;
                            registerFingerPrintRequest.IDNumber = item.IDNumber;
                            registerFingerPrintRequest.PhoneNumber = item.PhoneNumber;
                            registerFingerPrintRequest.Image = string.Empty;
                            registerFingerPrintRequest.ImageData = null;
                            registerFingerPrintRequest.ImageType = string.Empty;

                            registerFingerPrintRequests.Add(registerFingerPrintRequest);
                        }

                    }

                }

                Form1 form1 = new Form1(serviceManager, registerFingerPrintRequest);
                form1.Show();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public async Task<FetchPatientResponse> GetById(int Id)
        {
            try
            {
                var response = await serviceManager.PatientService.GetById(Id);
                if (response == null)
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

        public async Task<ApiResponse<FetchPatientResponse>> FindByCondition(FetchPatientRequest fetchPatientRequest)
        {
            try
            {
                var response = await serviceManager.PatientService.FindByCondition(fetchPatientRequest);
                if (!response.Successful == true)
                {
                    return new ApiResponse<FetchPatientResponse>
                    {
                        Successful = false,
                        Message = "Patient does not exist.",
                        Data = null
                    };

                }

                return new ApiResponse<FetchPatientResponse>
                {
                    Successful = true,
                    Message = null,
                    Data = response.Data
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<FetchPatientResponse>> FetchData(FetchPatientRequest fetchPatientRequest)
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

        private void InitializeGUI()
        {
            // Set the DataGridView properties
            registeredPatientsGridView.Dock = DockStyle.Fill; // Dock it to fill the entire form
            registeredPatientsGridView.AutoGenerateColumns = false; // Disable auto-generation of columns
            registeredPatientsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Allow selecting full rows

            // Create and add columns to the DataGridView
            DataGridViewTextBoxColumn patientIdColumn = new DataGridViewTextBoxColumn();
            patientIdColumn.DataPropertyName = "id"; // Bind to your data source property
            patientIdColumn.HeaderText = "Patient ID";
            registeredPatientsGridView.Columns.Add(patientIdColumn);

            DataGridViewTextBoxColumn patientFirstNameColumn = new DataGridViewTextBoxColumn();
            patientFirstNameColumn.DataPropertyName = "firstName";
            patientFirstNameColumn.HeaderText = "FirstName";
            registeredPatientsGridView.Columns.Add(patientFirstNameColumn);

            DataGridViewTextBoxColumn patientMiddleNameColumn = new DataGridViewTextBoxColumn();
            patientMiddleNameColumn.DataPropertyName = "middleName";
            patientMiddleNameColumn.HeaderText = "MiddleName";
            registeredPatientsGridView.Columns.Add(patientMiddleNameColumn);

            DataGridViewTextBoxColumn patientLastNameColumn = new DataGridViewTextBoxColumn();
            patientLastNameColumn.DataPropertyName = "lastName";
            patientLastNameColumn.HeaderText = "LastName";
            registeredPatientsGridView.Columns.Add(patientLastNameColumn);

            DataGridViewTextBoxColumn patientIPOPNumberColumn = new DataGridViewTextBoxColumn();
            patientIPOPNumberColumn.DataPropertyName = "patientIPOPNumber"; // Bind to your data source property
            patientIPOPNumberColumn.HeaderText = "IPOPNumber";
            registeredPatientsGridView.Columns.Add(patientIPOPNumberColumn);

            DataGridViewTextBoxColumn patientIdNumberColumn = new DataGridViewTextBoxColumn();
            patientIdNumberColumn.DataPropertyName = "patientIDNumber"; // Bind to your data source property
            patientIdNumberColumn.HeaderText = "IDNumber";
            registeredPatientsGridView.Columns.Add(patientIdNumberColumn);

            DataGridViewTextBoxColumn patientPhoneColumn = new DataGridViewTextBoxColumn();
            patientPhoneColumn.DataPropertyName = "patientPhone";
            patientPhoneColumn.HeaderText = "PhoneNumber";
            registeredPatientsGridView.Columns.Add(patientPhoneColumn);

            DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn();
            selectColumn.HeaderText = "Select";
            selectColumn.Name = "selectColumn";
            registeredPatientsGridView.Columns.Insert(0, selectColumn);




        }



    }
}
