using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public Guid ProductFk { get; set; }
        public  Product Product { get; set; }

        public Guid OrderFk { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
