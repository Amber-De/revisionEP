using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IProductsService
    {
        //we are going to return a product view model so we won't expose our original class.
        IQueryable<ProductViewModel> GetProducts();

        // void RateProduct(Guid id, string comment, double rating);

        ProductViewModel GetProduct(Guid id);

        void AddProduct(ProductViewModel data);

        void HideProduct(Guid id);
    }
}
