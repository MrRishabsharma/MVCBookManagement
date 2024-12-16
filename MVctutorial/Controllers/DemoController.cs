using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVctutorial.Controllers
{
    public class DemoController : Controller
    { 
    //{
    //   public string Hello()
    //   {
    //        return "Hello World how are you";
    //   }

    //    public int Add(int a,int b)
    //    {
    //        return a + b;
    //    }

       

        public ViewResult Demo()
        {

            ViewData["Products"] = new List<string>()
            {
                "samsung TV",
                "Nike TV"

            };


            return View();
        }
    }
}