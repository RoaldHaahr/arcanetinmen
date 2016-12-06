namespace ArcaneTinmen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteConfirmPassword : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "ConfirmPassword", c => c.String(nullable: false));
        }
    }
}
