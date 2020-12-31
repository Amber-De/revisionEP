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
using X.PagedList;

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

        [HttpGet]
        public IActionResult Index(int? page)
        {
            //Getting Categories
            var categoryList = _categoriesService.GetCategories();
            ViewBag.Categories = categoryList;

            //Getting products
            var list = _productsService.GetProducts();
            
            //Paging
            var pageNumber = page ?? 1;
            var onePageOfProducts = list.ToPagedList(pageNumber, 10);

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
           
        }

        [HttpPost]
        public IActionResult Index(string categoryName, int? page)
        {
            var categoryList = _categoriesService.GetCategories();
            ViewBag.Categories = categoryList;

            //get category id with this name
            var categoryId = _categoriesService.GetCategoryId(categoryName);
            var list = _productsService.GetProductsAccording(categoryId);
            //Paging
            var pageNumber = page ?? 1;
            var onePageOfProducts = list.ToPagedList(pageNumber, 10);
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
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

                TempData["warning"] = "Product was not added. Please check your details";  

            }

            var category_list = _categoriesService.GetCategories();
            ViewBag.Categories = category_list;

            return View();
        }

        public IActionResult Hide(Guid productId)
        {
            
            _productsService.HideProduct(productId);
            TempData["feedback"] = "Product was Hidden successfully";
            return RedirectToAction("Index");
            
        }
    }

}
