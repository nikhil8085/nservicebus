using System.Data.Entity;

namespace Samples.NServiceBus.Repositories
{
    public class DataContext : DbContext, IDataContext
    {
        static DataContext()
        {
            Database.SetInitializer<DataContext>(null);
        }

        public DataContext()
            : base("database")
        {
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
