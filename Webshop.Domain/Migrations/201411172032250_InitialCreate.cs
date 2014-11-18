namespace Samples.NServiceBus.Webshop.Domain
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocalDataStoreItems",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Key = c.String(),
                        ViewModelType = c.String(),
                        Data = c.String(),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LocalDataStoreItems");
        }
    }
}
