using Samples.NServiceBus.Repositories;
using System.Data.Entity;

namespace Samples.NServiceBus.Webshop.Domain
{
    public class LocalDataStoreDataContext : DbContext, IDataContext
    {
        public DbSet<LocalDataStoreItem> LocalDataStoreItems { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
