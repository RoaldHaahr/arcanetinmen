namespace ArcaneTinmen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GameSleeve");
            AddPrimaryKey("dbo.GameSleeve", new[] { "SleeveId", "GameId" });
            DropColumn("dbo.GameSleeve", "GameSleeveId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameSleeve", "GameSleeveId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.GameSleeve");
            AddPrimaryKey("dbo.GameSleeve", "GameSleeveId");
        }
    }
}
