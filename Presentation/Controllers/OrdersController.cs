using Microsoft.AspNetCore.Identity;
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

        public OrdersController(IOrdersService ordersService, IOrderDetailsService orderDetailsService, UserManager<IdentityUser> userManager)
        {
            _ordersService = ordersService;
            _orderDetailsService = orderDetailsService;
        }

        public IActionResult OrderDetails(Guid orderId)
        {
            var username =  User.Identity.Name;
            orderId = _orderDetailsService.GetOrderId(username);
            var list = _orderDetailsService.GetOrderDetails(orderId);
            //viewbag = to pass the total in the html.
            ViewBag.total = _orderDetailsService.Subtotal(orderId, username);
            return View(list);
        }
    }
}
