using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVctutorial.Models
{
    public class EmpDetailsContext:DbContext
    {
        public EmpDetailsContext() : base("ProductsConnection")
        {
           
        }
        public DbSet<EmpDetails> EMPDetails { get; set; }
        public DbSet<Bookstore> BookDetails { get; set; }
        public DbSet<Products> ProductsTable { get; set; }

        public DbSet<ProductsDetails> ProductVariant { get; set; }

    }
}