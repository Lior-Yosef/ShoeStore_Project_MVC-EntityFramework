namespace ShoeStore_Project_MVC_EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddElegantShoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ElegantShoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Gender = c.String(),
                        hasHeel = c.Boolean(nullable: false),
                        inStock = c.Boolean(nullable: false),
                        size = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ElegantShoes");
        }
    }
}
