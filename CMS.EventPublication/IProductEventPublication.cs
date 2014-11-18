using Samples.NServiceBus.CMS.Domain;
using System;

namespace Samples.NServiceBus.CMS.EventPublication
{
    public interface IProductEventPublication
    {
        void ProductWasAdded(Product product);
        void ProductWasRemoved(Product product);
        void ProductWasUpdated(Product product);
        void ProductWasPurchased(Product product);
    }
}
