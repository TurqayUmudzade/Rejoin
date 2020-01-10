namespace ReJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobForUser22 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "Users_UserID", "dbo.Users");
            DropIndex("dbo.Jobs", new[] { "Users_UserID" });
            DropColumn("dbo.Jobs", "Users_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Users_UserID", c => c.Int());
            CreateIndex("dbo.Jobs", "Users_UserID");
            AddForeignKey("dbo.Jobs", "Users_UserID", "dbo.Users", "UserID");
        }
    }
}
