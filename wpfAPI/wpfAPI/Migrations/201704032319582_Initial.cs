namespace wpfAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Things",
                c => new
                    {
                        ThingID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ThingInfo = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ThingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Things");
        }
    }
}
