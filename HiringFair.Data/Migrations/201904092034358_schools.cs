namespace HiringFair.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schools : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.School",
                c => new
                    {
                        SchoolId = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(),
                        SchoolLocation = c.String(),
                        YearsAtSchool = c.Int(nullable: false),
                        TypeOfDegree = c.String(),
                    })
                .PrimaryKey(t => t.SchoolId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.School");
        }
    }
}
