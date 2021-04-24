namespace DOICMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Complaints", "InvestigatorID", c => c.Int(nullable: false));
            AddColumn("dbo.Complaints", "AdminActionID", c => c.Int());
            AddColumn("dbo.Complaints", "AgentID", c => c.Int());
            AddColumn("dbo.Complaints", "InsurerID", c => c.Int());
            AddColumn("dbo.Complaints", "ConsumerID", c => c.Int());
            AddColumn("dbo.Complaints", "DateSubmitted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Complaints", "DateCompleted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Complaints", "DateCompleted");
            DropColumn("dbo.Complaints", "DateSubmitted");
            DropColumn("dbo.Complaints", "ConsumerID");
            DropColumn("dbo.Complaints", "InsurerID");
            DropColumn("dbo.Complaints", "AgentID");
            DropColumn("dbo.Complaints", "AdminActionID");
            DropColumn("dbo.Complaints", "InvestigatorID");
        }
    }
}
