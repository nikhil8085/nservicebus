using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Linq;
using System;

namespace Samples.NServiceBus.Webshop.Domain
{
    public interface ILocalDataStore
    {
        IEnumerable<T> GetEntities<T>() where T : class, new();
        T GetEntity<T>(string key) where T : class, new();
        T GetEntity<T>() where T : class, new();
        void SaveEntity<T>(string key, T entity) where T : class, new();
        void SaveEntity<T>(T entity) where T : class, new();
        void DeleteEntity<T>(string globalId) where T : class, new();
        void DeleteEntity<T>(T entity) where T : class, new();
    }
}