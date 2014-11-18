using Samples.NServiceBus.Repositories;
using System;

namespace Samples.NServiceBus.Webshop.Domain
{
    public class LocalDataStoreItem : EntityBase
    {
        public string Key { get; set; }
        public string ViewModelType { get; set; }
        public string Data { get; set; }
        public DateTime Updated { get; set; }
    }
}
