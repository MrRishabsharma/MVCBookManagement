using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVctutorial.Models
{
    public class BookAndProduct
    {

        public Bookstore Bookdetail { get; set; }
        public List<Products> productslist { get; set; }




    }
}