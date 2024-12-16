using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVctutorial.Models
{
    [Table("TblBookstore")]
    public class Bookstore
    {
        [Key]
        [Required(ErrorMessage = "Book ID is required.")]
        public int Bookid { get; set; }

        [Required(ErrorMessage = "Book Name is required.")]
        public string Bookname { get; set; }
        [Required]
        public string Author { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Sold date is required.")]
        public DateTime Soldate { get; set; }

    }
}