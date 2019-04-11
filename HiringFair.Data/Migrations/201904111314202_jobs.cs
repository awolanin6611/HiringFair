namespace HiringFair.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        JobField = c.String(nullable: false),
                        JobTitle = c.String(nullable: false),
                        JobDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.JobId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Job");
        }
    }
}
