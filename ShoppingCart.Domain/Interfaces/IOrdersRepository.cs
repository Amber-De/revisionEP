using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface IOrdersRepository
    { 
        //Creating a new order everytime a user checks out.
        void CreateOrder(Guid id);
    }
}
