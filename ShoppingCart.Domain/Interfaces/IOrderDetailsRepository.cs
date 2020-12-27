using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface IOrderDetailsRepository
    {
        IQueryable<OrderDetails> GetOrderDetails(Guid orderId);

        void DeleteOrderDetail(Guid id);
        void AddOrderDetails(Guid orderId, Guid productId); //Add an item->that item is orderDetails

        Guid GetOrderId(string userName);
        double Subtotal(Guid orderId, string userName);
    }
}
