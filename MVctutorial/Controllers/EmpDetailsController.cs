using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVctutorial.Models;
using System.Net;

namespace MVctutorial.Controllers
{
    public class EmpDetailsController : Controller
    {
        EmpDetailsContext DB = new EmpDetailsContext();
        public ActionResult HomePage()
        {
            return View(DB.EMPDetails.ToList()); 
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Emp number Required");
            }

            EmpDetails Empdet = DB.EMPDetails.Find(id);

            if(Empdet==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Emp number not found");
            }
            return View(Empdet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult PostEmpDetails()
        {

            EmpDetails Empdet = new EmpDetails();
            if (TryUpdateModel(Empdet))
            {
                DB.EMPDetails.Add(Empdet);
                DB.SaveChanges();
                return RedirectToAction("HomePage");
            }
            else
            {
                return View(Empdet);
            }

        }




    }
}