using zk4500.Shared.Dtos;

namespace zk4500.Shared.Requests
{
    public class FetchPatientForVerificationRequest : Request
    {
        public string ServicePoint { get; set; }

        public bool IsFingerVerified { get; set; }  


    }
}
