using NServiceBus;
using Samples.NServiceBus.Messages;
using Samples.NServiceBus.Messages.Commands;
using Samples.NServiceBus.Webshop.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Samples.NServiceBus.Webshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILocalDataStore localDataStore;
        private readonly IBus bus;

        public HomeController(ILocalDataStore localDataStore, IBus bus)
        {
            this.localDataStore = localDataStore;
            this.bus = bus;
        }

        public ActionResult Index()
        {
            return View(localDataStore.GetEntities<ProductDto>());
        }

        public ActionResult Details(string id)
        {
            return View(localDataStore.GetEntity<ProductDto>(id));
        }

        public ActionResult Purchase(Guid id)
        {
            var message = new PurchaseProductCommand() { Id = id };

#if (DEBUG)
            bus.Send("CMS#LOCAL", message);
#else
            bus.Send("CMS", message);
#endif

            return RedirectToAction("Index");
        }

        public ActionResult ToCMS()
        {
            HttpContext.Response.Redirect(ConfigurationManager.AppSettings["Sample.CMSUrl"]);
            return new EmptyResult();
        }
    }
}