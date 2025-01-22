using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVctutorial.Models
{
    [Table("ProductsDetails")]
    public class ProductsDetails
    {
        [Key]
        public int Id { get; set; }

        public string Productname { get; set; }

        public string ProductVariant { get; set; }





    }
}