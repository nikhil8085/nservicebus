﻿using NServiceBus;
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
            var products = localDataStore.GetEntities<ProductDto>();
            return View(products);
        }

        public ActionResult Details(string id)
        {
            var product = localDataStore.GetEntity<ProductDto>(id);
            return View(product);
        }

        public ActionResult Purchase(Guid id)
        {
            var message = new PurchaseProductCommand() { Id = id };
            bus.Send("CMS#LOCAL", message);
            return RedirectToAction("Index");
        }

        public ActionResult ToCMS()
        {
            HttpContext.Response.Redirect(ConfigurationManager.AppSettings["Sample.CMSUrl"]);
            return new EmptyResult();
        }
    }
}