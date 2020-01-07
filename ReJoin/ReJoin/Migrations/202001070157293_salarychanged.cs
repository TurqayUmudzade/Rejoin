namespace ReJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salarychanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "SalaryMin", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "SalaryMax", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "SalaryMax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Jobs", "SalaryMin", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
