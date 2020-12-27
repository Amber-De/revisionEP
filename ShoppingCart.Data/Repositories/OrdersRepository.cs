using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class OrdersRepository: IOrdersRepository
    {
        private ShoppingCartDbContext _context;
        private IOrderDetailsRepository _orderDetailsRepository;
        public OrdersRepository(ShoppingCartDbContext context, IOrderDetailsRepository orderDetailsRepository)
        {
            _context = context;
            _orderDetailsRepository = orderDetailsRepository;
        }

        public void FinalizeOrder(Guid orderId)
        {
            //Comparing the id from the Orders Table to the passing id
            var id  =_context.Orders.SingleOrDefault(x => x.Id == orderId);
            
            //Unless the id is null, update the time/date and match the price to the subtotal
            if(id != null)
            {
                id.DatePlace = DateTime.Now;
                id.TotalPrice = _orderDetailsRepository.Subtotal(orderId, id.Email);

                _context.Update(id);
                _context.SaveChanges();
            }
        }
    }
}
