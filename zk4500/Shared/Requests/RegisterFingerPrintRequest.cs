using zk4500.Shared.Dtos;

namespace zk4500.Shared.Requests
{
    public class RegisterFingerPrintRequest : Request
    {
        public int UserId { get; set; }
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string IPOPNumber { get; set; }
        public string IDNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
        public bool IsActive { get; set; }
        public int EntityType { get; set; } 

    }
}
