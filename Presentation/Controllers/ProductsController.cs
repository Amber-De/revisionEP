using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Application.Services;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Application.Interfaces;

namespace Presentation.Controllers
{
    public class ProductController : Controller
    {
        private IProductsService _productsService;
        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        /// <summary>
        /// Products Catalogue
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var list = _productsService.GetProducts();

            return View(list);
        }
    }
}
