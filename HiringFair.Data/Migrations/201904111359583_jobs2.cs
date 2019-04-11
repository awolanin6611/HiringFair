namespace HiringFair.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobs2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Job", "Employee_EmployeeId", c => c.Int());
            AddColumn("dbo.Job", "School_SchoolId", c => c.Int());
            CreateIndex("dbo.Job", "Employee_EmployeeId");
            CreateIndex("dbo.Job", "School_SchoolId");
            AddForeignKey("dbo.Job", "Employee_EmployeeId", "dbo.Employee", "EmployeeId");
            AddForeignKey("dbo.Job", "School_SchoolId", "dbo.School", "SchoolId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Job", "School_SchoolId", "dbo.School");
            DropForeignKey("dbo.Job", "Employee_EmployeeId", "dbo.Employee");
            DropIndex("dbo.Job", new[] { "School_SchoolId" });
            DropIndex("dbo.Job", new[] { "Employee_EmployeeId" });
            DropColumn("dbo.Job", "School_SchoolId");
            DropColumn("dbo.Job", "Employee_EmployeeId");
        }
    }
}
