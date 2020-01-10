namespace ReJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "PostUserID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "PostUserID", c => c.Int(nullable: false));
        }
    }
}
