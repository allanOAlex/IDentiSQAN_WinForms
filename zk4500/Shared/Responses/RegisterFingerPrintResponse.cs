using zk4500.Shared.Dtos;

namespace zk4500.Shared.Responses
{
    public class RegisterFingerPrintResponse : Response
    {
        public int UserId { get; set; }
        public int PatientId { get; set; }
        public string Image { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
        public bool IsActive { get; set; }
    }
}
