using System.ComponentModel.DataAnnotations;

namespace zk4500.Entities
{
    public class PatientForVerification
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Title { get; set; }
        public int CheckInID { get; set; }
        public string IPOPNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string ServicePointId { get; set; }
        public string ImageTemplate { get; set; }
        public bool IsFingerVerified { get; set; }
    }
}
