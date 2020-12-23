using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<OrderDetails> GetOrderDetails()
        {
            return _context.OrderDetails;
        }

        public OrderDetails GetOrderDetails(Guid id)
        {
            //returning a single item..If the id matches with the id that I am passing return it 
            //otherwise just return null.

            return _context.OrderDetails.Include(x => x.Order).SingleOrDefault(x => x.Id == id);
        }

        //pass an orderid,
        // With orderId get the total for all the products found inside one order
        // HINT: orderId is found inside orderDetails. Where every product has an orderId associated with it.

        // NEXT : ADD TO CART ---> Implement the 4 classes, Iservice,service,Irepository,repository
        // Test the methods by trying to add a product to a cart.
        // HINT: A row has to be added in orderDetails (Which represents the added product to your cart)
        //     : You can do this using only 1 parameter which is found inside the product/details view


        // STEPS TO GET SUBTOTAL OF EACH ITEM IN A LIST 

        // 1.) OrderId Guid DONE
        // 2.)Pass to Repo
        // 3.) Foreach ( var i in _context.OrderDetails)

        public double Subtotal(Guid orderId)
        {
            double total = 0;
            //with x from OrderDetails match orderFK with the id being passed on.
            foreach(var i in _context.OrderDetails.Where(x => x.OrderFk == orderId))
            {
                total += (i.Quantity * i.Product.Price);
            }

            return total;
        }
    }
}
