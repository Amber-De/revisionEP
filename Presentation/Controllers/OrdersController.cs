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
        IProductsService _productsService;

        //User manager is required to use User.Identity
        public OrdersController(IOrdersService ordersService, IOrderDetailsService orderDetailsService, UserManager<IdentityUser> userManager, IProductsService productsService)
        {
            _ordersService = ordersService;
            _orderDetailsService = orderDetailsService;
            _productsService = productsService;
        }

        public IActionResult OrderDetails(Guid orderId, Guid productId)
        {
            var prodId = _productsService.GetProduct(productId);
            var username =  User.Identity.Name;
            orderId = _orderDetailsService.GetOrderId(username);
            var list = _orderDetailsService.GetOrderDetails(orderId);
            //viewbag = to pass the total in the html.
            ViewBag.total = _orderDetailsService.Subtotal(orderId, username);

            return View(list);
        }

        public IActionResult AddingToCart(Guid productId)
        {
            var username = User.Identity.Name;
            Guid orderId = _orderDetailsService.GetOrderId(username);
            _orderDetailsService.AddOrderDetails(orderId, productId);

            TempData["feedback"] = "Product was added successfully !";
            return RedirectToAction("OrderDetails");
        }
    }
}
