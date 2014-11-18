using NServiceBus;
using Samples.NServiceBus.Messages;
using Samples.NServiceBus.Messages.Events;
using Samples.NServiceBus.Webshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.NServiceBus.Webshop.Handlers
{
    public class ProductEventHandler : IHandleMessages<ProductWasAdded>, IHandleMessages<ProductWasUpdated>, IHandleMessages<ProductWasRemoved>, IHandleMessages<ProductWasPurchased>
    {
        private readonly ILocalDataStore localDataStore;

        public ProductEventHandler(ILocalDataStore localDataStore)
        {
            this.localDataStore = localDataStore;
        }

        public void Handle(ProductWasAdded message)
        {
            localDataStore.SaveEntity<ProductDto>(message.Product.Id.ToString(), message.Product);
        }

        public void Handle(ProductWasUpdated message)
        {
            localDataStore.SaveEntity<ProductDto>(message.Product.Id.ToString(), message.Product);
        }

        public void Handle(ProductWasRemoved message)
        {
            localDataStore.DeleteEntity<ProductDto>(message.Product.Id.ToString());
        }

        public void Handle(ProductWasPurchased message)
        {
            localDataStore.SaveEntity<ProductDto>(message.Product.Id.ToString(), message.Product);
            // in this demo example, I don't process this message. But you could use it to asynchronously present the user with a confirmation page after purchase
        }
    }
}
