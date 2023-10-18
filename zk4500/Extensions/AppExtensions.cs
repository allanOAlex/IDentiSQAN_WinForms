using AxZKFPEngXControl;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using zk4500.Abstractions.Interfaces;
using zk4500.ApiClient;
using zk4500.Enums;
using zk4500.Forms;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;

namespace zk4500.Extensions
{
    public static class AppExtensions
    {

        private static AxZKFPEngX ZkFprint = new AxZKFPEngX();
        private static readonly IServiceManager serviceManager;
        private static readonly IAuthApiClient authApiClient;


        public static int DepartmentId { get; set; } = 14;
        public static int Environment { get; set; } = (int)Env.Dev;
        public static string Connection { get; set; }
        public static int SelectedId { get; set; }
        public static int RowId { get; set; }
        public static bool BitValue { get; set; }
        public static int UpdateQueryResult { get; set; }
        public static string CheckInTimeStamp { get; set; }
        public static int CaptureAction { get; set; }
        public static int GridRefreshed { get; set; }
        public static int DeviceConnected { get; set; }
        public static int UserId { get; set; }
        public static int PatientId { get; set; }
        public static string UserImageTemplate { get; set; }
        public static bool IsPatient { get; set; }
        public static string CTO { get; set; }
        public static int ManageBrowserUsingBrowserManagerClass { get; set; } = 1;
        public static DataGridView registeredPatientsGridView { get; set; }
        public static FetchUserResponse FetchUserResponse { get; set; }
        public static VerifyFingerPrintRequest VerifyFingerPrintRequest { get; set; }
        public static LoginRequest LoginRequest { get; set; }
        public static List<FetchPatientForVerificationResponse> PatientsForVerificationList { get; set; }
        public static Dictionary<int, string> UserImageTemplates { get; set; }
        



        public static string GetConnection(int Id)
        {
            if (Id != 0)
            {
                return Connection = "promed_bwh";
            }

            return Connection = "Promed";
        }

        public static string GetDB(int Id)
        {
            if (Id != 0)
            {
                return Connection = "promed_bwh";
            }

            return Connection = "Promed";
        }

        public static bool HasProperty(dynamic obj, string propertyName)
        {
            try
            {
                var value = obj.GetType().GetProperty(propertyName)?.GetValue(obj, null);
                return value != null;
            }
            catch
            {
                return false;
            }
        }

        public static void ManageGridColumns(DataGridView registeredPatientsGridView)
        {
            try
            {
                List<string> readOnlyColumns = new List<string>
                {
                    "IsFingerVerified",
                    "ColumnName2"
                };

                List<string> hiddenColumns = new List<string>
                {
                    "Id",
                    "UserId",
                    "Password",
                    "ImageTemplate"
                };

                foreach (DataGridViewColumn column in registeredPatientsGridView.Columns)
                {
                    if (readOnlyColumns.Contains(column.Name))
                    {
                        column.ReadOnly = true;
                    }

                    if (hiddenColumns.Contains(column.Name))
                    {
                        column.Visible = false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static string HashPassword(this string password)
        {
            // Generate a unique salt for each user (random bytes)
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // Create the password hash (PBKDF2)
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Combine the salt and hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convert the byte array to a base64-encoded string
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }

        public static void ReturnToMain()
        {
            List<Form> formsToClose = new List<Form>();

            // First, collect the forms to close
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name != "Form1")
                {
                    formsToClose.Add(form);
                }
            }

            // Now, close the collected forms
            foreach (Form form in formsToClose)
            {
                form.Close();
        }

            // Finally, show the Main form
            Form1 mainForm = new Form1(serviceManager, authApiClient);
            mainForm.Enabled = true;
            mainForm.Show();
        }

        public static string RandomString()
        {
            try
            {
                int length = 10; // Length of the random string
                string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                string hashedString = string.Empty;

                Random random = new Random();
                StringBuilder result = new StringBuilder(length);

                for (int i = 0; i < length; i++)
                {
                    int index = random.Next(characters.Length);
                    result.Append(characters[index]);
                }

                string randomString = result.ToString();

                byte[] inputData = Encoding.UTF8.GetBytes(randomString);

                // Create an instance of SHA-256
                using (SHA256 sha256 = SHA256.Create())
                {
                    // Compute the hash value
                    byte[] hashBytes = sha256.ComputeHash(inputData);

                    // Convert the hash bytes to a hexadecimal string
                    hashedString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                }

                return hashedString;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string RandomQuadString()
        {
            try
            {
                int length = 4; // Length of the random string
                string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

                Random random = new Random();
                StringBuilder result = new StringBuilder(length);

                for (int i = 0; i < length; i++)
                {
                    int index = random.Next(characters.Length);
                    result.Append(characters[index]);
                }

                string randomString = result.ToString();

                return randomString;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static string ToString(this DateTime? dt, string format) => dt == null ? "n/a" : ((DateTime)dt).ToString(format);
        public static string ToString(this DateTimeOffset? dt, string format) => dt == null ? "n/a" : ((DateTimeOffset)dt).ToString(format);


        





    }
}
