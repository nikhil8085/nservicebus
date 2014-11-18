using NServiceBus;
using Samples.NServiceBus.CMS.Domain;
using Samples.NServiceBus.CMS.EventPublication;
using Samples.NServiceBus.Messages.Commands;
using Samples.NServiceBus.Messages.Events;
using Samples.NServiceBus.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.NServiceBus.CMS.Handlers
{
    public class ProductEventHandler : IHandleMessages<PurchaseProductCommand>
    {
        private readonly IRepository<Product> productRepository;
        private readonly IProductEventPublication productEventPublication;

        public ProductEventHandler(IRepository<Product> productRepository, IProductEventPublication productEventPublication)
        {
            this.productRepository = productRepository;
            this.productEventPublication = productEventPublication;
        }

        public void Handle(PurchaseProductCommand message)
        {
            var product = productRepository.GetById(message.Id);
            product.Purchased = true;
            productRepository.SaveChanges();

            productEventPublication.ProductWasPurchased(product);
        }
    }
}
