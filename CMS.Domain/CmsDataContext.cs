using Samples.NServiceBus.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.NServiceBus.CMS.Domain
{
    public class CmsDataContext : DbContext, IDataContext
    {
        public DbSet<Product> Products { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
