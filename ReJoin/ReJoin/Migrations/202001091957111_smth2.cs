namespace ReJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smth2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobAds", "User_UserID1", "dbo.Users");
            DropIndex("dbo.JobAds", new[] { "User_UserID1" });
            DropColumn("dbo.JobAds", "User_UserID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobAds", "User_UserID1", c => c.Int());
            CreateIndex("dbo.JobAds", "User_UserID1");
            AddForeignKey("dbo.JobAds", "User_UserID1", "dbo.Users", "UserID");
        }
    }
}
