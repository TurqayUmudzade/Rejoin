namespace ReJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FacebookLink", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "TwitterLink", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "GoogleLink", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "PinteresLink", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PinteresLink");
            DropColumn("dbo.Users", "GoogleLink");
            DropColumn("dbo.Users", "TwitterLink");
            DropColumn("dbo.Users", "FacebookLink");
        }
    }
}
