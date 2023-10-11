using zk4500.Shared.Dtos;

namespace zk4500.Shared.Requests
{
    public class VerifyFingerPrintRequest : Request
    {
        public string Username { get; set; }
        public string Password { get; set; }



    }
}
