﻿using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface IProductsRepository
    {
        //the design of what we are going to implement

        IQueryable<Product> GetProducts();

        Product GetProduct(Guid id);
        void AddProduct(Product p);
        void DeleteProduct(Guid id);
    }
}
