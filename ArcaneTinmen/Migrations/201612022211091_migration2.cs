namespace ArcaneTinmen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.OrderPlacement",
                c => new
                    {
                        OrderPlacementId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        DatePlaced = c.DateTime(nullable: false),
                        DateShipped = c.DateTime(nullable: false),
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
                        SleeveId = c.Int(nullable: false),
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
                        SleeveId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SleeveId);
            
            CreateTable(
                "dbo.GameSleeve",
                c => new
                    {
                        GameSleeveId = c.Int(nullable: false, identity: true),
                        SleeveId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameSleeveId)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Sleeve", t => t.SleeveId, cascadeDelete: true)
                .Index(t => t.SleeveId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
            DropTable("dbo.Admin");
        }
    }
}
