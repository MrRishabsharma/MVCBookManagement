﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVctutorial.Models;
using PagedList;

namespace MVctutorial.Controllers
{
    public class BookStoreController : Controller
    {
        EmpDetailsContext DB = new EmpDetailsContext();
      
        public ActionResult Index(int? page)
        {
            int pageSize =5; 
            int pageNumber = page ?? 1; 
            var items = DB.BookDetails.OrderBy(x => x.Bookid).ToList();

            var pagedList = items.ToPagedList(pageNumber, pageSize);

            return View(pagedList); 
        }

        public ActionResult Create()
        {
            var viewModel = new BookAndProduct
            {
                Bookdetail = new Bookstore(),
                productslist = DB.ProductsTable.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAndProduct viewModel)
        {
            if (ModelState.IsValid)
            {
                DB.BookDetails.Add(viewModel.Bookdetail);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                viewModel.productslist = DB.ProductsTable.ToList();
                return View(viewModel);
            }
        }

        public ActionResult Intial()
        {
            return View();
        }


        public ActionResult Lookup(int? id)
        {
            if (id != null)
            {
                ViewBag.DataCount = DB.BookDetails.Where(e => e.Bookid == id).ToList().Count;
                return View(DB.BookDetails.Where(e => e.Bookid == id).ToList());
            }
            else
            {
                ViewBag.DataCount = DB.BookDetails.ToList().Count;
                return View(DB.BookDetails.ToList());
            }
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // Handle null id
            }
            // Fetch the Bookstore record for the given id
            var book = DB.BookDetails.FirstOrDefault(b => b.Bookid == id); // Replace 'BookstoreTable' with your actual table

            if (book == null)
            {
                return HttpNotFound(); // Handle non-existent book
            }

            var viewModel = new BookAndProduct
            {
                Bookdetail = book, // Populate with the fetched book details
                productslist = DB.ProductsTable.ToList() // Assuming this is required for dropdowns or other purposes
            };

            return View(viewModel);
        }

       public JsonResult Getproduct(string countryID)
       {
            var states = DB.ProductVariant.Where(s => s.Productname == countryID).
                Select(s => new
                {
                    Id = s.Productname,
                    Name = s.ProductVariant
                }).ToList();

            return Json(states, JsonRequestBehavior.AllowGet);
       }




    }
}