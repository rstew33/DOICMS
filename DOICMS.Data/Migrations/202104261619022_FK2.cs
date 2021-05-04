namespace DOICMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdminAction", "ComplaintID", c => c.Int());
            CreateIndex("dbo.Complaint", "AdminActionID");
            AddForeignKey("dbo.Complaint", "AdminActionID", "dbo.AdminAction", "AdminActionID");
            DropColumn("dbo.Investigator", "ComplaintID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Investigator", "ComplaintID", c => c.Int());
            DropForeignKey("dbo.Complaint", "AdminActionID", "dbo.AdminAction");
            DropIndex("dbo.Complaint", new[] { "AdminActionID" });
            DropColumn("dbo.AdminAction", "ComplaintID");
        }
    }
}
