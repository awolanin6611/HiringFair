namespace HiringFair.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobtoemployer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Job", "Employee_EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Job", "Employer_EmployerId", "dbo.Employer");
            DropIndex("dbo.Job", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Job", new[] { "Employer_EmployerId" });
            RenameColumn(table: "dbo.Job", name: "Employee_EmployeeId", newName: "EmployeeId");
            RenameColumn(table: "dbo.Job", name: "Employer_EmployerId", newName: "EmployerId");
            AlterColumn("dbo.Job", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Job", "EmployerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Job", "EmployeeId");
            CreateIndex("dbo.Job", "EmployerId");
            AddForeignKey("dbo.Job", "EmployeeId", "dbo.Employee", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.Job", "EmployerId", "dbo.Employer", "EmployerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Job", "EmployerId", "dbo.Employer");
            DropForeignKey("dbo.Job", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.Job", new[] { "EmployerId" });
            DropIndex("dbo.Job", new[] { "EmployeeId" });
            AlterColumn("dbo.Job", "EmployerId", c => c.Int());
            AlterColumn("dbo.Job", "EmployeeId", c => c.Int());
            RenameColumn(table: "dbo.Job", name: "EmployerId", newName: "Employer_EmployerId");
            RenameColumn(table: "dbo.Job", name: "EmployeeId", newName: "Employee_EmployeeId");
            CreateIndex("dbo.Job", "Employer_EmployerId");
            CreateIndex("dbo.Job", "Employee_EmployeeId");
            AddForeignKey("dbo.Job", "Employer_EmployerId", "dbo.Employer", "EmployerId");
            AddForeignKey("dbo.Job", "Employee_EmployeeId", "dbo.Employee", "EmployeeId");
        }
    }
}
