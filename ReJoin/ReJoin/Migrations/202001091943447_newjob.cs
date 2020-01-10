namespace ReJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newjob : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobAds",
                c => new
                    {
                        JobID = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(nullable: false, maxLength: 50),
                        JobType = c.String(nullable: false, maxLength: 50),
                        JobRole = c.String(nullable: false, maxLength: 50),
                        SalaryMin = c.Int(nullable: false),
                        SalaryMax = c.Int(nullable: false),
                        Exprience = c.Int(nullable: false),
                        Eligibility = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 100),
                        Country = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 300),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        picture = c.String(),
                        RecruiterEmail = c.String(nullable: false, maxLength: 100),
                        RecruiterPhoneNumber = c.String(nullable: false, maxLength: 100),
                        RecruiterAdress = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.JobID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobAds");
        }
    }
}
