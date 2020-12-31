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

        public IActionResult OrderDetails()
        {

            var username =  User.Identity.Name;
            if(username != null)
            {
                var orderId = _orderDetailsService.GetOrderId(username);

                var list = _orderDetailsService.GetOrderDetails(orderId);
                //viewbag = to pass the total in the html.
                ViewBag.total = _orderDetailsService.Subtotal(orderId, username);

                return View(list);
            }
            else
            {
                return View();
            }
           
        }

        public IActionResult AddingToCart(Guid productId)
        {
            var username = User.Identity.Name;
            Guid orderId = _orderDetailsService.GetOrderId(username);
            bool orderDetails =  _orderDetailsService.AddOrderDetails(orderId, productId);
            if(orderDetails == false)
            {
                TempData["warning"] = "Product was Out of stock!";
                return RedirectToAction("Index","Products");
            }

            TempData["feedback"] = "Product was added successfully !";
            return RedirectToAction("OrderDetails");
        }

        public IActionResult Checkout(Guid orderId, Guid productId)
        {

            var username = User.Identity.Name;
            orderId = _orderDetailsService.GetOrderId(username);
             _ordersService.CheckOut(orderId);
            ViewBag.Id = orderId;
            var prodId = _productsService.GetProduct(productId);
            ViewBag.prod = prodId;

            var productIds = _orderDetailsService.GetProductIds(orderId);
            _productsService.ReduceStock(productIds,orderId);

            TempData["feedback"] = "Order was completed successfully !";
            return RedirectToAction("OrderDetails");
        }
    }
}
