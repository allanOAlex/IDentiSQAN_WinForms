using zk4500.Shared.Dtos;

namespace zk4500.Shared.Requests
{
    public class FetchFingerPrintRequest : Request
    {
        public int PatientId { get; set; }

    }
}
