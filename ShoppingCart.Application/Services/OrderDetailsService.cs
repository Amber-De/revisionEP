using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private IMapper _mapper;

        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepo, IMapper mapper)
        {
            _orderDetailsRepo = orderDetailsRepo;
            _mapper = mapper;
        }

        public IQueryable<OrderDetailsViewModel> GetOrderDetails(Guid orderId)
        {
            /*
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
            */

            return _orderDetailsRepo.GetOrderDetails(orderId).ProjectTo<OrderDetailsViewModel>(_mapper.ConfigurationProvider);
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

        public Boolean AddOrderDetails(Guid orderId, Guid productId)
        {
            return _orderDetailsRepo.AddOrderDetails(orderId, productId);
        }

        public IQueryable<Guid> GetProductIds(Guid orderId)
        {
            return _orderDetailsRepo.GetProductIds(orderId);
        }
    }
}
