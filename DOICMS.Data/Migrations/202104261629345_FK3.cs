namespace DOICMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Complaint", "AgentID");
            CreateIndex("dbo.Complaint", "InsurerID");
            CreateIndex("dbo.Complaint", "ConsumerID");
            AddForeignKey("dbo.Complaint", "AgentID", "dbo.Agent", "AgentID");
            AddForeignKey("dbo.Complaint", "ConsumerID", "dbo.Consumer", "ConsumerID");
            AddForeignKey("dbo.Complaint", "InsurerID", "dbo.Insurer", "InsurerID");
            DropColumn("dbo.AdminAction", "ComplaintID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdminAction", "ComplaintID", c => c.Int());
            DropForeignKey("dbo.Complaint", "InsurerID", "dbo.Insurer");
            DropForeignKey("dbo.Complaint", "ConsumerID", "dbo.Consumer");
            DropForeignKey("dbo.Complaint", "AgentID", "dbo.Agent");
            DropIndex("dbo.Complaint", new[] { "ConsumerID" });
            DropIndex("dbo.Complaint", new[] { "InsurerID" });
            DropIndex("dbo.Complaint", new[] { "AgentID" });
        }
    }
}
