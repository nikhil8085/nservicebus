namespace Samples.NServiceBus.CMS.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPurchaseToggle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Purchased", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Purchased");
        }
    }
}
