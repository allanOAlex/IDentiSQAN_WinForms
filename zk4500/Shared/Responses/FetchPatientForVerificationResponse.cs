using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zk4500.Shared.Dtos;

namespace zk4500.Shared.Responses
{
    public class FetchPatientForVerificationResponse : Response
    {
        public int CheckInID { get; set; }
        public string Title { get; set; }
        public string IPOPNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string ServicePointId { get; set; }
        public string ImageTemplate { get; set; }
        public bool IsFingerVerified { get; set; }


    }
}
