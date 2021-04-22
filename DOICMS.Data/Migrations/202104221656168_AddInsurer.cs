namespace DOICMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInsurer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Insurer",
                c => new
                    {
                        InsurerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InsurerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Insurer");
        }
    }
}
