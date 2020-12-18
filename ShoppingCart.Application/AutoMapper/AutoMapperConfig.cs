using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.AutoMapper
{
    //It will configure the AutoMapper instance that is going to be initializde by
    //the runtime to use these two profiles made up of mappings.
    //AutoMapper >> Configiration >> Profiles
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(

                cfg =>
                {
                    cfg.AddProfile(new DomainToViewModelProfile());
                    cfg.AddProfile(new ViewModelToDomainProfile());
                }

                );
        }
    }
}
