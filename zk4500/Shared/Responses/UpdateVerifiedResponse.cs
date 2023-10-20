using zk4500.Shared.Dtos;

namespace zk4500.Shared.Responses
{
    public class UpdateVerifiedResponse : Response
    {
        public int CheckInPatientId { get; set; }
        public bool IsFingerVerified { get; set; }
    }
}
