namespace DOICMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminAction",
                c => new
                    {
                        AdminActionID = c.Int(nullable: false, identity: true),
                        OrderType = c.String(nullable: false),
                        InvestigatorID = c.Int(nullable: false),
                        AgentID = c.Int(),
                        InsurerID = c.Int(),
                    })
                .PrimaryKey(t => t.AdminActionID);
            
            CreateTable(
                "dbo.Complaints",
                c => new
                    {
                        ComplaintID = c.Int(nullable: false, identity: true),
                        ComplaintDesc = c.String(),
                        Resolved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ComplaintID);
            
            CreateTable(
                "dbo.Consumer",
                c => new
                    {
                        ConsumerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ConsumerID);
            
            CreateTable(
                "dbo.Investigator",
                c => new
                    {
                        InvestigatorID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InvestigatorID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Investigator");
            DropTable("dbo.Consumer");
            DropTable("dbo.Complaints");
            DropTable("dbo.AdminAction");
        }
    }
}
