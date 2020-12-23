using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class OrdersController : Controller
    {
        IOrdersService _ordersService;
        IOrderDetailsService _orderDetailsService;
        
        public OrdersController(IOrdersService ordersService, IOrderDetailsService orderDetailsService)
        {
            _ordersService = ordersService;
            _orderDetailsService = orderDetailsService;
        }
        public IActionResult OrderDetails(Guid orderId)
        {
            var list = _orderDetailsService.GetOrderDetails();
            ViewBag.total = _orderDetailsService.Subtotal(orderId);
            return View(list);
        }
        //reseacrh how to get logged in user information
        //create method to get order id in the service u l repo
        //b xi mod gib l email biex fejn l order id jkun jaqbel.
    }
}
