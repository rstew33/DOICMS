namespace DOICMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newviews : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Complaint", "DateSubmitted", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Complaint", "DateCompleted", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Complaint", "DateCompleted", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Complaint", "DateSubmitted", c => c.DateTime(nullable: false));
        }
    }
}
