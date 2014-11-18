using System.Collections.Generic;
using System;
using System.Linq;
using Newtonsoft.Json;

namespace Samples.NServiceBus.Webshop.Domain
{
    public class LocalDataStore : ILocalDataStore
    {
        private readonly ILocalDataRepository repository;

        public LocalDataStore(ILocalDataRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<T> GetEntities<T>() where T : class, new()
        {
            return repository.GetByType<T>().ToList().Select(l => JsonConvert.DeserializeObject<T>(l.Data));
        }

        public T GetEntity<T>(string key) where T : class, new()
        {
            var model = repository.GetByKeyAndType<T>(key);

            if (model == null)
            {
                return null;
            }
            
            return JsonConvert.DeserializeObject<T>(model.Data);
        }

        public T GetEntity<T>() where T : class, new()
        {
            return GetEntity<T>(typeof(T).ToString());
        }

        public void SaveEntity<T>(string key, T entity) where T : class, new()
        {
            var model = repository.GetByKeyAndType<T>(key);

            if (model == null)
            {
                model = new LocalDataStoreItem
                {
                    Key = key,
                    ViewModelType = typeof(T).ToString(),
                    Data = JsonConvert.SerializeObject(entity),
                    Updated = DateTime.Now
                };

                repository.Insert(model);
                repository.SaveChanges();
            }
            else
            {
                model.Data = JsonConvert.SerializeObject(entity);
                model.Updated = DateTime.Now;
                repository.SaveChanges();
            }
        }

        public void SaveEntity<T>(T entity) where T : class, new()
        {
            SaveEntity(typeof(T).ToString(), entity);
        }

        public void DeleteEntity<T>(string key) where T : class, new()
        {
            var model = repository.GetByKeyAndType<T>(key);

            if (model != null)
            {
                repository.Delete(model);
                repository.SaveChanges();
            }
        }

        public void DeleteEntity<T>(T entity) where T : class, new()
        {
            DeleteEntity<T>(typeof(T).ToString());
        }
    }
}