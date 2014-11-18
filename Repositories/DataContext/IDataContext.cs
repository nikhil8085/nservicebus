using System.Data.Entity;

namespace Samples.NServiceBus.Repositories
{
    public interface IDataContext
    {
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }
}