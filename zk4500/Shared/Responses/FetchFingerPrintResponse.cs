using zk4500.Shared.Dtos;

namespace zk4500.Shared.Responses
{
    public class FetchFingerPrintResponse : Response
    {
        public int PatientId { get; set; }
        public string ImageTemplate { get; set; }
        public bool IsActive { get; set; }
    }
}
