namespace ReJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "PostUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "PostUserID", c => c.Int());
        }
    }
}
