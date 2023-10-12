using System.ComponentModel.DataAnnotations;

namespace zk4500.Entities
{
    public class User
    {
        [Key]
        public string Title { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string OtherNames { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public int IsActive { get; set; }


    }
}
