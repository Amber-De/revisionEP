using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private ShoppingCartDbContext _context;

        public OrderDetailsRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public void AddOrderDetails(Guid orderId, Guid productId)
        {
            //Creating a new order detail
            OrderDetails o = new OrderDetails();
            o.OrderFk = orderId;
            o.ProductFk = productId;
            o.SellingPrice = _context.Products.SingleOrDefault(x => x.Id == productId).Price;

            var orderDetail = _context.OrderDetails.FirstOrDefault(x => x.ProductFk == productId && x.OrderFk == orderId);

            //If there is this product already in the list and the user clicks on add to cart again -> increase the quantity.
            if (orderDetail == null)
            {
                o.Quantity = 1;
                _context.Add(o);
                _context.SaveChanges();
            }
            else
            {
                orderDetail.Quantity++;
                _context.Update(orderDetail);
                _context.SaveChanges();
            }


        }
        
        public void DeleteOrderDetail(Guid id)
        {
            //removing an item from the list
            throw new NotImplementedException();
        }

        public IQueryable<OrderDetails> GetOrderDetails(Guid orderid)
        {
            var testing = _context.OrderDetails.Where(x => x.OrderFk == orderid);
            return testing;
        }

        public double Subtotal(Guid orderId, string userName)
        {
            double total = 0;
            //Matching orderFK with the id being passed on.
            foreach(var i in _context.OrderDetails.Where(x => x.OrderFk == orderId).ToList())
            {
                total += (i.Quantity * i.Product.Price);
            }

            return total;
        }

        public Guid GetOrderId(string userName)
        {
            DateTime dt1 = new DateTime(1900, 01, 01, 0, 0, 0);
            var order = _context.Orders.Where(x => x.Email == userName).SingleOrDefault(x => x.DatePlace == dt1);

            //If the user has never added to a cart before, they do not have an order id -> so we create one
            if (order == null)
            {
                Order o = new Order();
                o.DatePlace = dt1;
                o.Email = userName;

                _context.Add(o);
                _context.SaveChanges();

                order = _context.Orders.Where(x => x.Email == userName).SingleOrDefault(x => x.DatePlace == dt1);
            }

            return order.Id;
        }
    }
}
