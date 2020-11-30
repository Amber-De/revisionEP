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
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        public ProductsController(IProductsService productsService)
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

        public IActionResult Details(Guid id)
        {
          var myProduct =   _productsService.GetProduct(id);

            return View(myProduct);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //we are just showing the user a page to fill in
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel data)
        {
            //this method is after the user clicks add or submit
            //Validation such as if the email is good, category wise, price is not below 0 or with (-).
            try
            {
                _productsService.AddProduct(data);
            }catch(Exception e)
            {
                //log errors
            }

            return View();
        }
    }
}
