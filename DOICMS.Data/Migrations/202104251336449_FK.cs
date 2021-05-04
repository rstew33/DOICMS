namespace DOICMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investigator", "ComplaintID", c => c.Int());
            CreateIndex("dbo.Complaint", "InvestigatorID");
            AddForeignKey("dbo.Complaint", "InvestigatorID", "dbo.Investigator", "InvestigatorID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Complaint", "InvestigatorID", "dbo.Investigator");
            DropIndex("dbo.Complaint", new[] { "InvestigatorID" });
            DropColumn("dbo.Investigator", "ComplaintID");
        }
    }
}
