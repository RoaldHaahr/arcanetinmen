namespace ArcaneTinmen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GameSleeve");
            AddColumn("dbo.GameSleeve", "GameSleeveId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.GameSleeve", "GameSleeveId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.GameSleeve");
            DropColumn("dbo.GameSleeve", "GameSleeveId");
            AddPrimaryKey("dbo.GameSleeve", new[] { "SleeveId", "GameId" });
        }
    }
}
