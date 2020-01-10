namespace ReJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobadCreatedAT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobAds", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobAds", "CreatedAt");
        }
    }
}
