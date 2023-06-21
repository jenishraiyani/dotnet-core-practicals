using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerceMVC.Models
{
    public class Product
    {

        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter validate price"), Required]
        public decimal Price { get; set; }

        [Required]
        public int IsInStock { get; set; }
 
        
        
    }
}