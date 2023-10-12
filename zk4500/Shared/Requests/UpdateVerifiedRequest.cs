using zk4500.Shared.Dtos;

namespace zk4500.Shared.Requests
{
    public class UpdateVerifiedRequest : Request
    {
        public int CheckInPatientId { get; set; }
        public bool IsFingerVerified { get; set; }


    }
}
