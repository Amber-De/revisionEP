using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {

        //whenever i am going to use this class to connect with the db, as soon as i initialise it(calling its constructor) 
        //you're going to pass immediately an instance of shopping cart db context and inside its implementation i am assigning it into
        //a field into my class -> which will be accessible from every other method.

        private ShoppingCartDbContext _context;
        public ProductsRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public void AddProduct(Product p)
        {
            //context has a list of products and I need to add p..adding to the local list of products my new product
            _context.Products.Add(p);
            _context.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            var myProduct = GetProduct(id);
            
           // _context.Products.Remove(myProduct);
           // _context.SaveChanges();

        }
        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }

        public Product GetProduct(Guid id)
        {
            //single or default will be used whenever you are going to return just one record. Go through all the products(x)
            //evaluate this condition..and when you find a product which satisfies this condition(the product id matches the 
            //product)I'm passing, return it. If it doesnt find a product, it will return null.
            
            //lazyloading - it is only loaded if it is asked to.
            return _context.Products.Include(x => x.Category).SingleOrDefault(x => x.Id == id);
        }
    }
}
