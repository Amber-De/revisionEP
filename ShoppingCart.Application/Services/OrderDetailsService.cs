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

        public IQueryable<OrderDetailsViewModel> GetOrderDetails(Guid orderId)
        {
            var list = from o in _orderDetailsRepo.GetOrderDetails(orderId)
                       select new OrderDetailsViewModel()
                       {
                           Id = o.Id,
                           Quantity = o.Quantity,
                           SellingPrice = o.SellingPrice,
                           Product = new ProductViewModel() { Name = o.Product.Name, ImageUrl = o.Product.ImageUrl, Price = o.Product.Price },
                           Order = new OrderViewModel() { TotalPrice = o.Order.TotalPrice }

                       };


            return list;

        }

        public Guid GetOrderId(string userName)
        {
            Guid id = _orderDetailsRepo.GetOrderId(userName);

            return id;
        }

        public double Subtotal(Guid orderId, string userName)
        {
            double total = _orderDetailsRepo.Subtotal(orderId, userName);
            
            return total;
        }

        public void AddOrderDetails(Guid orderId, Guid productId)
        {
            _orderDetailsRepo.AddOrderDetails(orderId, productId);
        }
    }
}
