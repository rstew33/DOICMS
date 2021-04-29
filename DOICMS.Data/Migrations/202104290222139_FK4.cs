namespace DOICMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK4 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AdminAction", "InvestigatorID");
            AddForeignKey("dbo.AdminAction", "InvestigatorID", "dbo.Investigator", "InvestigatorID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminAction", "InvestigatorID", "dbo.Investigator");
            DropIndex("dbo.AdminAction", new[] { "InvestigatorID" });
        }
    }
}
