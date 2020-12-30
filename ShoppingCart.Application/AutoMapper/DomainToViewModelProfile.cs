using AutoMapper;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        //These profiles are there because we need to let the automapper know about these mappings we want to define.
        public DomainToViewModelProfile()
        {
            //Product >> ProductViewModel
            //We use this line of code because our properties in both classes are the same

            CreateMap<Product, ProductViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Member, MemberViewModel>();

            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderDetails, OrderDetailsViewModel>();
        }
        
    }
}
