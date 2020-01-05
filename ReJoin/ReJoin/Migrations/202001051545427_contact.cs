namespace ReJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        ContactInfoID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Message = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ContactInfoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactInfoes");
        }
    }
}
