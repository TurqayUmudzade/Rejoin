namespace ReJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PhoneNumber", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "Adress", c => c.String(maxLength: 100));
            AddColumn("dbo.Users", "City", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "PostolZipCode", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "Country", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "AboutMe", c => c.String(maxLength: 500));
            AddColumn("dbo.Users", "picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "picture");
            DropColumn("dbo.Users", "AboutMe");
            DropColumn("dbo.Users", "Country");
            DropColumn("dbo.Users", "PostolZipCode");
            DropColumn("dbo.Users", "City");
            DropColumn("dbo.Users", "Adress");
            DropColumn("dbo.Users", "PhoneNumber");
        }
    }
}
