namespace ReJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smth : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Jobs", new[] { "User_UserID" });
            DropIndex("dbo.Jobs", new[] { "User_UserID1" });
            AddColumn("dbo.JobAds", "PostUserID", c => c.Int());
            AddColumn("dbo.JobAds", "User_UserID", c => c.Int());
            AddColumn("dbo.JobAds", "User_UserID1", c => c.Int());
            CreateIndex("dbo.JobAds", "User_UserID");
            CreateIndex("dbo.JobAds", "User_UserID1");
            DropTable("dbo.Jobs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Jobs",
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
                        User_UserID = c.Int(),
                        User_UserID1 = c.Int(),
                    })
                .PrimaryKey(t => t.JobID);
            
            DropIndex("dbo.JobAds", new[] { "User_UserID1" });
            DropIndex("dbo.JobAds", new[] { "User_UserID" });
            DropColumn("dbo.JobAds", "User_UserID1");
            DropColumn("dbo.JobAds", "User_UserID");
            DropColumn("dbo.JobAds", "PostUserID");
            CreateIndex("dbo.Jobs", "User_UserID1");
            CreateIndex("dbo.Jobs", "User_UserID");
        }
    }
}
