namespace ArcaneTinmen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GameSleeve");
            AddColumn("dbo.Customer", "Password", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.Customer", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Admin", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.OrderPlacement", "DatePlaced", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.OrderPlacement", "DateShipped", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Game", "Name", c => c.String(nullable: false));
            AddPrimaryKey("dbo.GameSleeve", new[] { "SleeveId", "GameId" });
            DropColumn("dbo.GameSleeve", "GameSleeveId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameSleeve", "GameSleeveId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.GameSleeve");
            AlterColumn("dbo.Game", "Name", c => c.String());
            AlterColumn("dbo.OrderPlacement", "DateShipped", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrderPlacement", "DatePlaced", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customer", "Email", c => c.String());
            AlterColumn("dbo.Customer", "Address", c => c.String());
            AlterColumn("dbo.Customer", "LastName", c => c.String());
            AlterColumn("dbo.Customer", "FirstName", c => c.String());
            AlterColumn("dbo.Admin", "Email", c => c.String());
            DropColumn("dbo.Customer", "ConfirmPassword");
            DropColumn("dbo.Customer", "Password");
            AddPrimaryKey("dbo.GameSleeve", "GameSleeveId");
        }
    }
}
