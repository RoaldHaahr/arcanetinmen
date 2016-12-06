namespace ArcaneTinmen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 12),
                        ConfirmPassword = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Zip = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderPlacement",
                c => new
                    {
                        OrderPlacementId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        DatePlaced = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateShipped = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderPlacementId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderLine",
                c => new
                    {
                        OrderLineId = c.Int(nullable: false, identity: true),
                        OrderPlacementId = c.Int(nullable: false),
                        SleeveId = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderLineId)
                .ForeignKey("dbo.OrderPlacement", t => t.OrderPlacementId, cascadeDelete: true)
                .ForeignKey("dbo.Sleeve", t => t.SleeveId, cascadeDelete: true)
                .Index(t => t.OrderPlacementId)
                .Index(t => t.SleeveId);
            
            CreateTable(
                "dbo.Sleeve",
                c => new
                    {
                        SleeveId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        SalePrice = c.Double(nullable: false),
                        StockAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SleeveId);
            
            CreateTable(
                "dbo.GameSleeve",
                c => new
                    {
                        SleeveId = c.String(nullable: false, maxLength: 128),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SleeveId, t.GameId })
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Sleeve", t => t.SleeveId, cascadeDelete: true)
                .Index(t => t.SleeveId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLine", "SleeveId", "dbo.Sleeve");
            DropForeignKey("dbo.GameSleeve", "SleeveId", "dbo.Sleeve");
            DropForeignKey("dbo.GameSleeve", "GameId", "dbo.Game");
            DropForeignKey("dbo.OrderLine", "OrderPlacementId", "dbo.OrderPlacement");
            DropForeignKey("dbo.OrderPlacement", "CustomerId", "dbo.Customer");
            DropIndex("dbo.GameSleeve", new[] { "GameId" });
            DropIndex("dbo.GameSleeve", new[] { "SleeveId" });
            DropIndex("dbo.OrderLine", new[] { "SleeveId" });
            DropIndex("dbo.OrderLine", new[] { "OrderPlacementId" });
            DropIndex("dbo.OrderPlacement", new[] { "CustomerId" });
            DropTable("dbo.Game");
            DropTable("dbo.GameSleeve");
            DropTable("dbo.Sleeve");
            DropTable("dbo.OrderLine");
            DropTable("dbo.OrderPlacement");
            DropTable("dbo.Customer");
            DropTable("dbo.Admin");
        }
    }
}
