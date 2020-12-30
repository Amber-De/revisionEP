using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private ShoppingCartDbContext _context;
        public CategoriesRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public IQueryable<Category> GetCategories()
        {
            return _context.Categories;
        }

        public int GetCategoryId(string categoryName)
        {
            var categoryId = _context.Categories.SingleOrDefault(x => x.Name == categoryName).Id;

            return categoryId;
        }
    }
}
