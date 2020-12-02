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
        private ICategoriesService _categoriesService;

        //Adding an instance in order to load categories
        public ProductsController(IProductsService productsService, ICategoriesService categoriesService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
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

            //bringing a list of categories from the database
            var category_list = _categoriesService.GetCategories();

            //we are just showing the user a page to fill in.
            //Since we cannot just pass category_list(Because the view has the ProductViewModel whilst categoryList has CategoryViewModel)so we use viewbag
            ViewBag.Categories = category_list;

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
                TempData["feedback"] = "Product was added successfully";
                ModelState.Clear();

            }catch(Exception e)
            {
                //log errors

                TempData["warning"] = "Product was not added. Please check your details";  

            }

            var category_list = _categoriesService.GetCategories();
            ViewBag.Categories = category_list;

            return View();
        }

        public IActionResult Delete(Guid id)
        {
            //try catch for assignment
            _productsService.DeleteProduct(id);
            TempData["feedback"] = "Product was deleted successfully";
            return RedirectToAction("Index");
            
        }
    }

}
