using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamQuestion.Models
{
    public class Products
    {
        [Required]
        public int ProductId { get; set; }

       
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Product Name")]
        public string ProductName { get; set; }

        
        [Required(ErrorMessage = "Enter Rate")]
        public decimal Rate { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Product Description")]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Category Name")]
        public string CategoryName { get; set; }
    }
}