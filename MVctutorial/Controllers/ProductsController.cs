using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVctutorial.Models;
using System.Net;

namespace MVctutorial.Controllers
{
    public class ProductsController : Controller
    {
        ProductsData db = new ProductsData();
        ProductsContext db2 = new ProductsContext();

        public ViewResult Index()
        {
            return View(db.ProductsList.ToList());
        }

        public ViewResult Index3()
        {
            return View(db2.ProductsTable.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product ID Required");           
            }
           Products product= db2.ProductsTable.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }

            return View(product);

        }

        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost] first way if accessing the form controls
        //public ActionResult Create(FormCollection frmcollection)
        //{
        //    Products product = new Products();
        //    product.Name = frmcollection["Name"];
        //    product.Price = Convert.ToDecimal( frmcollection["Price"]);
        //    db2.ProductsTable.Add(product);
        //    db2.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        [ActionName("Create")]
        public ActionResult PostProduct()
        {
            Products product = new Products();

            if (TryUpdateModel(product))
            {
                db2.ProductsTable.Add(product);
                db2.SaveChanges();
                return RedirectToAction("Index3");
            }
            else
            {
                // Handle the case where model binding fails
                // You can return the view with the product model to show validation errors
                return View(product);
            }
        }
    }
}