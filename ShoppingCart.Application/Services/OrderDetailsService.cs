using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class OrderDetailsService: IOrderDetailsService
    {
        private IOrderDetailsRepository _orderDetailsRepo;

        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepo)
        {
            _orderDetailsRepo = orderDetailsRepo;
        }

        public IQueryable<OrderDetailsViewModel> GetOrderDetails()
        {
            var list = from o in _orderDetailsRepo.GetOrderDetails()
                       select new OrderDetailsViewModel()
                       {
                           Id = o.Id,
                           Quantity = o.Quantity,
                           SellingPrice = o.SellingPrice,
                           Product = new ProductViewModel() { Name = o.Product.Name, ImageUrl = o.Product.ImageUrl },
                           Order = new OrderViewModel () { TotalPrice = o.Order.TotalPrice}

                       };
            return list;
        }

        public OrderDetailsViewModel GetOrderDetails(Guid id)
        {
            OrderDetailsViewModel myModel = new OrderDetailsViewModel();
            var orderDb = _orderDetailsRepo.GetOrderDetails(id);

            myModel.Id = orderDb.Id;
            myModel.Quantity = orderDb.Quantity;
            myModel.SellingPrice = orderDb.SellingPrice;

            myModel.Product = new ProductViewModel();
            myModel.Product.Name = orderDb.Product.Name;
            myModel.Product.ImageUrl = orderDb.Product.ImageUrl;

            myModel.Order = new OrderViewModel();
            myModel.Order.TotalPrice = orderDb.Order.TotalPrice;

            return myModel;
        }

    }
}
