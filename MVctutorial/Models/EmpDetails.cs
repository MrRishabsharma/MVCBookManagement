using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVctutorial.Models
{
    [Table("HRD_EMP_MST")]
    public class EmpDetails
    {
        [Key]
        public int Emp_no { get; set; }
        [Required]
        public string Emp_name { get; set; }
        public string Emp_phone { get; set; }
        public string Emp_Email { get; set; }
        public int Emp_Salary { get; set; }
        [Required]
        public string Emp_Department { get; set; }
        [Required]
        public string Emp_Join_dt { get; set; }
    }
}