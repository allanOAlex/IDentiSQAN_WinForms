namespace zk4500.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FingerPrints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        Image = c.String(),
                        ImageData = c.Binary(),
                        ImageType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        AlternativePhone = c.String(),
                        GenderId = c.Int(nullable: false),
                        PatientTitle = c.String(),
                        PostalAddress = c.String(),
                        PostalCode = c.String(),
                        Location = c.String(),
                        SubLocation = c.String(),
                        Village = c.String(),
                        NearestSchool = c.String(),
                        IDNumber = c.String(),
                        HomeAddress = c.String(),
                        DateOfBirth = c.DateTimeOffset(nullable: false, precision: 7),
                        HasInsuarance = c.Boolean(nullable: false),
                        FullKinName = c.String(),
                        KinMobileNumber = c.String(),
                        KinRelationShip = c.String(),
                        PatientPhoto = c.String(),
                        UIP = c.String(),
                        UPC = c.String(),
                        IsActive = c.String(),
                        DatePosted = c.DateTimeOffset(nullable: false, precision: 7),
                        PostedByUID = c.Int(nullable: false),
                        IPOPNumber = c.Int(nullable: false),
                        InsuranceMemberNuber = c.String(),
                        KinEmail = c.String(),
                        UpdatedByUID = c.Int(nullable: false),
                        EducationLevelID = c.Int(nullable: false),
                        Occupation = c.Int(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                        IsMCHChild = c.Boolean(nullable: false),
                        FingerID = c.Int(nullable: false),
                        FingerData = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
            DropTable("dbo.FingerPrints");
        }
    }
}
