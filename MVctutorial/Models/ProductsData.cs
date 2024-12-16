using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVctutorial.Models
{
    public class ProductsData
    {
        public IEnumerable<Products> ProductsList
        {
            get
            {
                List<Products> products = new List<Products>()
                {
                    new Products{ProductID=1,Name="Samsung TV",Price=4545},
                    new Products{ProductID=2,Name="Nokia",Price=45454}
                };
                return products;
            }
        }
    }
}