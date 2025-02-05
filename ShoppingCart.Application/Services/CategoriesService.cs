﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CategoriesService : ICategoriesService
    {
        private IMapper _mapper;
        private ICategoriesRepository _categoryRepo;

        public CategoriesService(ICategoriesRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public IQueryable<CategoryViewModel> GetCategories()
        {
            return _categoryRepo.GetCategories().ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider);
        }

        public int GetCategoryId(string categoryName)
        {
            return _categoryRepo.GetCategoryId(categoryName);
        }
    }
}
