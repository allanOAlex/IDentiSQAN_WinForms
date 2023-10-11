using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zk4500.Shared.Dtos;

namespace zk4500.Shared.Requests
{
    public class FetchPatientRequest : Request
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string IPOPNumber { get; set; }
        public string IDNumber { get; set; }
        public string PhoneNumber { get; set; }

    }
}
