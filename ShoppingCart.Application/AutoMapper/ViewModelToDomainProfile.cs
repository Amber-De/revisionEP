using AutoMapper;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.AutoMapper
{
    public class ViewModelToDomainProfile: Profile
    {
        public ViewModelToDomainProfile()
        {
            //For the catgeory when getting it from the source just ignore -> leaving the category null
            CreateMap<ProductViewModel, Product>().ForMember(x => x.Category, opt => opt.Ignore());
            CreateMap<CategoryViewModel, Product>();
            CreateMap<MemberViewModel, Product>();
            
            CreateMap<OrderViewModel, Order>();
            CreateMap<OrderDetailsViewModel, OrderDetails>();
            
        }
    }
}
