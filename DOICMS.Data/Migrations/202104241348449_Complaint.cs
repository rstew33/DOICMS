namespace DOICMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Complaint : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Complaints", newName: "Complaint");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Complaint", newName: "Complaints");
        }
    }
}
