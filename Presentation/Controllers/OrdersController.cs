using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class OrdersController : Controller
    {
        IOrdersService _ordersService;
        
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        public IActionResult OrderDetails(s)
        {
            return View();
        }

    }
}
