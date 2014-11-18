using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.NServiceBus.Messages.Events
{
    public class ProductEventBase
    {
        public ProductDto Product { get; set; }
    }
}
