﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class ProductsService : IProductsService
    {
        private IProductsRepository _productRepo;
        private IMapper _mapper;

        public ProductsService(IProductsRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public IQueryable<ProductViewModel> GetProducts()
        {
            //Product  >>>  ProductViewModel
            //Project to is a way to map from one type to the other however ONLY when you have a queryable datatype
            return _productRepo.GetProducts().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
        }

        public ProductViewModel GetProduct(Guid productId)
        {
            //ProductViewModel <<<<<< Auto Mapper <<<<< Product
            //To eleminate all these lines of code we're going to "map" what we have in product to the viewmodel.

            Product product = _productRepo.GetProduct(productId);
            var resultingProductViewModel = _mapper.Map<ProductViewModel>(product);

            return resultingProductViewModel;
        }

        public void AddProduct(ProductViewModel data)
        {
            //Product  >>>  ProductViewModel
            var prod = _mapper.Map<Product>(data);
            _productRepo.AddProduct(prod);
        }

        public void HideProduct(Guid id)
        {
            if(_productRepo.GetProduct(id) != null)
            {
                _productRepo.HideProduct(id);
            }

        }

        public IQueryable<ProductViewModel> GetProductsAccording(int categoryId)
        {
           return _productRepo.GetProductsAccording(categoryId).ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);

        }

        public void ReduceStock(IQueryable<Guid> ProductIds,Guid orderId)
        {
             _productRepo.ReduceStock(ProductIds,orderId);
        }
    }
}
