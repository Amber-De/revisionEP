using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface IOrderDetailsRepository
    {
        IQueryable<OrderDetails> GetOrderDetails();
        OrderDetails GetOrderDetails(Guid id);

        void DeleteOrderDetail(Guid id);
        void AddOrderDetails(OrderDetails od); //Add an item->that item is orderDetails
        double Subtotal(Guid orderId);
    }
}
