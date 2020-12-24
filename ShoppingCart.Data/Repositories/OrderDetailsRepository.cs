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

        public void AddOrderDetails(OrderDetails od)
        {
            throw new NotImplementedException();
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


        //pass an orderid,
        // With orderId get the total for all the products found inside one order
        // HINT: orderId is found inside orderDetails. Where every product has an orderId associated with it.

        // NEXT : ADD TO CART ---> Implement the 4 classes, Iservice,service,Irepository,repository
        // Test the methods by trying to add a product to a cart.
        // HINT: A row has to be added in orderDetails (Which represents the added product to your cart)
        //     : You can do this using only 1 parameter which is found inside the product/details view

        public double Subtotal(Guid orderId, string userName)
        {
            double total = 0;
            //with x from OrderDetails match orderFK with the id being passed on.
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

            return order.Id;
        }
    }
}
