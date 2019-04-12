namespace HiringFair.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Job", "School_SchoolId", "dbo.School");
            DropIndex("dbo.Job", new[] { "School_SchoolId" });
            CreateTable(
                "dbo.Employer",
                c => new
                    {
                        EmployerId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyLocation = c.String(),
                    })
                .PrimaryKey(t => t.EmployerId);
            
            AddColumn("dbo.Job", "Employer_EmployerId", c => c.Int());
            CreateIndex("dbo.Job", "Employer_EmployerId");
            AddForeignKey("dbo.Job", "Employer_EmployerId", "dbo.Employer", "EmployerId");
            DropColumn("dbo.Job", "School_SchoolId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Job", "School_SchoolId", c => c.Int());
            DropForeignKey("dbo.Job", "Employer_EmployerId", "dbo.Employer");
            DropIndex("dbo.Job", new[] { "Employer_EmployerId" });
            DropColumn("dbo.Job", "Employer_EmployerId");
            DropTable("dbo.Employer");
            CreateIndex("dbo.Job", "School_SchoolId");
            AddForeignKey("dbo.Job", "School_SchoolId", "dbo.School", "SchoolId");
        }
    }
}
