using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.NServiceBus.Messages.Commands
{
    public class PurchaseProductCommand
    {
        public Guid Id { get; set; }
    }
}
