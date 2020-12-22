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
            throw new NotImplementedException();
        }
    }
}
