
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {
        // IService Collection a list being used by the runtime, made up of a number of objects, something built in - there by default, asking for a connection string
        //aswell.
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {

            services.AddDbContext<ShoppingCartDbContext>(options =>
                 options.UseSqlServer(connectionString));

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();

            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICategoriesService, CategoriesService>();

            services.AddScoped<IMembersRepository, MembersRepository>();
            services.AddScoped<IMembersService, MembersService>();
            
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IOrdersService, OrdersService>();

            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddScoped<IOrderDetailsService, OrderDetailsService>();
            

            //This is the way how we add automapper to the service collection
            services.AddAutoMapper(typeof(AutoMapperConfig));
            //Registers the profile with any instances will be initialized
            AutoMapperConfig.RegisterMappings();
        }
    }
}
