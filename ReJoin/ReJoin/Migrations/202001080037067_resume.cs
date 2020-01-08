namespace ReJoin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resume : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationId = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(),
                        Qualification = c.String(),
                        PeriodStart = c.String(),
                        PeriodEnd = c.String(),
                        Board = c.String(),
                        Resume_ResumeID = c.Int(),
                    })
                .PrimaryKey(t => t.EducationId)
                .ForeignKey("dbo.Resumes", t => t.Resume_ResumeID)
                .Index(t => t.Resume_ResumeID);
            
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        ResumeID = c.Int(nullable: false, identity: true),
                        Fullname = c.String(maxLength: 100),
                        JobProfession = c.String(maxLength: 100),
                        ExprienceYear = c.Int(nullable: false),
                        ExprienceMonth = c.Int(nullable: false),
                        PhoneNumber = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        Picture = c.String(),
                        PersonalSkill = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ResumeID);
            
            CreateTable(
                "dbo.WorkExpriences",
                c => new
                    {
                        WorkXPId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Position = c.String(),
                        PeriodStart = c.String(),
                        PeriodEnd = c.String(),
                        Resume_ResumeID = c.Int(),
                    })
                .PrimaryKey(t => t.WorkXPId)
                .ForeignKey("dbo.Resumes", t => t.Resume_ResumeID)
                .Index(t => t.Resume_ResumeID);
            
            AddColumn("dbo.Users", "Resume_ResumeID", c => c.Int());
            CreateIndex("dbo.Users", "Resume_ResumeID");
            AddForeignKey("dbo.Users", "Resume_ResumeID", "dbo.Resumes", "ResumeID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Resume_ResumeID", "dbo.Resumes");
            DropForeignKey("dbo.WorkExpriences", "Resume_ResumeID", "dbo.Resumes");
            DropForeignKey("dbo.Educations", "Resume_ResumeID", "dbo.Resumes");
            DropIndex("dbo.Users", new[] { "Resume_ResumeID" });
            DropIndex("dbo.WorkExpriences", new[] { "Resume_ResumeID" });
            DropIndex("dbo.Educations", new[] { "Resume_ResumeID" });
            DropColumn("dbo.Users", "Resume_ResumeID");
            DropTable("dbo.WorkExpriences");
            DropTable("dbo.Resumes");
            DropTable("dbo.Educations");
        }
    }
}
