using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IOrderDetailsService
    {
        IQueryable<OrderDetailsViewModel> GetOrderDetails(Guid orderId);

        Boolean AddOrderDetails(Guid orderId, Guid productId);
        Guid GetOrderId(string userName);
        double Subtotal(Guid orderId, string userName);

        IQueryable<Guid> GetProductIds(Guid orderId);

    }
}
