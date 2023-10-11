using System.ComponentModel;

namespace zk4500.Shared.Dtos
{
    public class Response
    {
        //public bool ContainsData { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("IP/OP Number")]
        public string IPOPNumber { get; set; }

        [DisplayName("Department Id")]
        public int DepartmentId { get; set; }

        [DisplayName("ID Number")]
        public string IDNumber { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Image Template")]
        public string ImageTemplate { get; set; }

        public int IsActive { get; set; }
        
    }
}
