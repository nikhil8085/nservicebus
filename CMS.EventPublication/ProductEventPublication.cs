using AutoMapper;
using NServiceBus;
using Samples.NServiceBus.CMS.Domain;
using Samples.NServiceBus.Messages;
using Samples.NServiceBus.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.NServiceBus.CMS.EventPublication
{
    public class ProductEventPublication : IProductEventPublication
    {
        private readonly IBus bus;

        public ProductEventPublication(IBus bus)
        {
            this.bus = bus;
            Mapper.CreateMap<Product, ProductDto>();
        }

        public void ProductWasAdded(Product product)
        {
            PublishProductEvent<ProductWasAdded>(product);
        }

        public void ProductWasUpdated(Product product)
        {
            PublishProductEvent<ProductWasUpdated>(product);
        }

        public void ProductWasRemoved(Product product)
        {
            PublishProductEvent<ProductWasRemoved>(product);
        }

        public void ProductWasPurchased(Product product)
        {
            PublishProductEvent<ProductWasPurchased>(product);
        }

        private void PublishProductEvent<T>(Product product) where T : ProductEventBase, new()
        {
            var message = new T();
            message.Product = Mapper.Map<ProductDto>(product);
            bus.Publish<T>(message);
        }
    }
}
