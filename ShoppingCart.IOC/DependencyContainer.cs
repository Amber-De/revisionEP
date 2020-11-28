using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {
        // IService Collection a list being used by the runtime, made up of a number of objects, something built in - there by default
        public static void RegisterService(IServiceCollection services)

        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();
        }
    }
}
