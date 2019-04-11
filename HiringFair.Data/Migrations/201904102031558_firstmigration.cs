namespace HiringFair.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "SchoolId", "dbo.School");
            DropIndex("dbo.Employee", new[] { "SchoolId" });
            RenameColumn(table: "dbo.Employee", name: "SchoolId", newName: "School_SchoolId");
            AlterColumn("dbo.Employee", "School_SchoolId", c => c.Int());
            CreateIndex("dbo.Employee", "School_SchoolId");
            AddForeignKey("dbo.Employee", "School_SchoolId", "dbo.School", "SchoolId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "School_SchoolId", "dbo.School");
            DropIndex("dbo.Employee", new[] { "School_SchoolId" });
            AlterColumn("dbo.Employee", "School_SchoolId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Employee", name: "School_SchoolId", newName: "SchoolId");
            CreateIndex("dbo.Employee", "SchoolId");
            AddForeignKey("dbo.Employee", "SchoolId", "dbo.School", "SchoolId", cascadeDelete: true);
        }
    }
}
