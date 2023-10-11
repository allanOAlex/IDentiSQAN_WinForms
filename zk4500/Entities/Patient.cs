using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace zk4500.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternativePhone { get; set; }
        public int GenderId { get; set; }
        public string Title { get; set; }
        public string PostalAddress { get; set; }
        public string PostalCode { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string Village { get; set; }
        public string NearestSchool { get; set; }
        public string IDNumber { get; set; }
        public string HomeAddress { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public bool HasInsuarance { get; set; }
        public string FullKinName { get; set; }
        public string KinMobileNumber { get; set; }
        public string KinRelationShip { get; set; }
        public string PatientPhoto { get; set; }
        public string UIP { get; set; }
        public string UPC { get; set; }
        public string IsActive { get; set; }
        public DateTimeOffset DatePosted { get; set; }
        public int PostedByUID { get; set; }
        public string IPOPNumber { get; set; }
        public string InsuranceMemberNuber { get; set; }
        public string KinEmail { get; set; }
        public int UpdatedByUID { get; set; }
        public int EducationLevelID { get; set; }
        public int Occupation { get; set; }
        public int MaritalStatus { get; set; }
        public bool IsMCHChild { get; set; }
        public int FingerID { get; set; }
        public string FingerData { get; set; }



    }
}
