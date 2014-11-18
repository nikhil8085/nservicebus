using Samples.NServiceBus.Repositories;
using System;
using System.Linq;

namespace Samples.NServiceBus.Webshop.Domain
{
    public interface ILocalDataRepository : IRepository<LocalDataStoreItem>
    {
        LocalDataStoreItem GetByKeyAndType<T>(string key);
        IQueryable<LocalDataStoreItem> GetByType<T>();
    }

    public class LocalDataRepository : Repository<LocalDataStoreItem>, ILocalDataRepository
    {
        public LocalDataRepository(IDataContext dataContext)
            : base(dataContext)
        {
        }

        public LocalDataStoreItem GetByKeyAndType<T>(string key)
        {
            var messageType = typeof(T).ToString();

            return GetQueryable()
                .FirstOrDefault(p => p.Key == key && p.ViewModelType == messageType);
        }

        public IQueryable<LocalDataStoreItem> GetByType<T>()
        {
            var messageType = typeof(T).ToString();

            return GetQueryable()
                .Where(p => p.ViewModelType == messageType);
        }
    }
}