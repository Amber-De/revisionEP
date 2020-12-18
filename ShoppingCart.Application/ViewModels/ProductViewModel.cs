using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class ProductViewModel
    {
        //declaring what I need to return to the user
        public Guid Id { get; set; }
        [Required()]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a price")]
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public CategoryViewModel Category { get; set; }
        /*
        public int Stock { get; set; }

        public double WholeSalePrice { get; set; }

        public string Supplier { get; set; }
        */
    }
}
