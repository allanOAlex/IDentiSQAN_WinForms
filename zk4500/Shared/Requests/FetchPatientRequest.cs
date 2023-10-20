using zk4500.Shared.Dtos;

namespace zk4500.Shared.Requests
{
    public class FetchPatientRequest : Request
    {
        public string IPOPNumber { get; set; }
        public string IDNumber { get; set; }

    }
}
