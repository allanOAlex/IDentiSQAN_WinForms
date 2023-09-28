using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zk4500.Shared.Responses;

namespace zk4500.Extensions
{
    public static class AppExtensions
    {
        public static int DepartmentId { get; set; } = 2;
        public static List<FetchPatientForVerificationResponse> PatientsForVerificationList { get; set; }



        // Helper method to check if a property exists on an object
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

    }
}
