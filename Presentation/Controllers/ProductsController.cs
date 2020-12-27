using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Application.Services;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;


namespace Presentation.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        private ICategoriesService _categoriesService;
        private IWebHostEnvironment _env;

        //Adding an instance in order to load categories
        public ProductsController(IProductsService productsService, ICategoriesService categoriesService, IWebHostEnvironment env)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _env = env;
        }

        /// <summary>
        /// Products Catalogue
        /// </summary>
        /// <returns></returns>
        /// 


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
        [Authorize(Roles ="Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductViewModel data, IFormFile file)
        {
            //this method is after the user clicks add or submit
            //Validation such as if the email is good, category wise, price is not below 0 or with (-).
            try
            {
                if(file != null)
                {
                    //image file names should be unique.
                    string newFilename = Guid.NewGuid() + System.IO.Path.GetExtension(file.FileName);
                    string absolutePath = _env.WebRootPath + @"\Images\";

                    //we are receiving file and copying it to a stream object

                    using (var stream = System.IO.File.Create(absolutePath + newFilename))
                    {
                        file.CopyTo(stream);
                    }

                    //this will go inside the database cause we don't put the full path, just the relative path
                    data.ImageUrl = @"\Images\" + newFilename;
                }
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

        public IActionResult Hide(Guid productId)
        {
            //try catch for assignment
            _productsService.HideProduct(productId);
            TempData["feedback"] = "Product was Hidden successfully";
            return RedirectToAction("Index");
            
        }
    }

}
