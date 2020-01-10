namespace ReJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobForUser221 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "PostUserID", c => c.Int(nullable: false));
            DropColumn("dbo.Jobs", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Jobs", "PostUserID");
        }
    }
}
