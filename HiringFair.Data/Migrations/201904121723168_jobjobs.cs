namespace HiringFair.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobjobs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Job", "CompanyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Job", "CompanyName", c => c.String());
        }
    }
}
