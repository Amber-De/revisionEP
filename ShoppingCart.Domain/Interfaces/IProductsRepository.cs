using ShoppingCart.Domain.Models;
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

        IQueryable<Product> GetProductsAccording(int categoryId);

        Product GetProduct(Guid productId);
        void AddProduct(Product p);
        void HideProduct(Guid id);

        void ReduceStock(IQueryable<Guid>ProductIds,Guid orderId);
    }
}
