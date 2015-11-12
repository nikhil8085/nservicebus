using Samples.NServiceBus.CMS.Domain;
using Samples.NServiceBus.CMS.EventPublication;
using Samples.NServiceBus.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Samples.NServiceBus.CMS
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> productRepository;
        private readonly IProductEventPublication productEventPublication;

        public ProductController(IRepository<Product> productRepository, IProductEventPublication productEventPublication)
        {
            this.productRepository = productRepository;
            this.productEventPublication = productEventPublication;
        }

        public ActionResult Index()
        {
            return View(productRepository.GetAll());
        }

        public ActionResult Details(Guid id)
        {
            var product = productRepository.GetById(id);
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Insert(product);
                productRepository.SaveChanges();

                productEventPublication.ProductWasAdded(product);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            var product = productRepository.GetById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, Product product)
        {
            if (ModelState.IsValid)
            {
                var dbProduct = productRepository.GetById(id);
                dbProduct.Name = product.Name;
                dbProduct.Price = product.Price;
                dbProduct.Description = product.Description;
                dbProduct.Purchased = product.Purchased;
                productRepository.SaveChanges();

                productEventPublication.ProductWasUpdated(product);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            var product = productRepository.GetById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(Guid id, Product product)
        {
            try
            {
                var dbProduct = productRepository.GetById(id);
                productRepository.Delete(dbProduct);
                productRepository.SaveChanges();

                productEventPublication.ProductWasRemoved(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ToWebshop()
        {
            HttpContext.Response.Redirect(ConfigurationManager.AppSettings["Sample.WebshopUrl"]);
            return new EmptyResult();
        }
    }
}
