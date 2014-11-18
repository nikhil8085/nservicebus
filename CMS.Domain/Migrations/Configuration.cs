namespace Samples.NServiceBus.CMS.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Samples.NServiceBus.CMS.Domain.CmsDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Samples.NServiceBus.CMS.Domain.CmsDataContext context)
        {
        }
    }
}
