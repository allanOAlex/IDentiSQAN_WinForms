using System.ComponentModel.DataAnnotations;

namespace zk4500.Entities
{
    public class FingerPrint
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PatientId { get; set; }
        public string ImageTemplate { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }
        public bool IsActive { get; set; }


    }
}
