using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    interface IOrdersService
    {
       void CheckOut(List<Product> productsInCart);
    }
}
