using System.ComponentModel;
using zk4500.Shared.Dtos;

namespace zk4500.Shared.Responses
{
    public class FetchPatientForVerificationResponse : Response
    {
        public int CheckInID { get; set; }
        
        [DisplayName("Service Point")]
        public string ServicePointId { get; set; }

        [DisplayName("Finger Verified")]
        public bool IsFingerVerified { get; set; }


    }
}
