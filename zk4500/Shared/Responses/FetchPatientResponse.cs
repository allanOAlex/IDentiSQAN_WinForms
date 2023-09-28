using zk4500.Shared.Dtos;

namespace zk4500.Shared.Responses
{
    public class FetchPatientResponse : Response
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string IPOPNumber { get; set; }
        public string IDNumber { get; set; }
        public string PhoneNumber { get; set; }



    }
}
