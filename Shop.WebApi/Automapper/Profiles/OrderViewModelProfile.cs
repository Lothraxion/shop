using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Shop.BLL.DTO;
using Show.WebApi.Models;

namespace Show.WebApi.Automapper.Profiles
{
    public class OrderViewModelProfile:Profile
    {
        public OrderViewModelProfile()
        {
            CreateMap<ProductDTO, string>().ConstructUsing(c => c.Name);
            CreateMap<OrderCartDTO, OrderViewModel>().ForMember(x => x.productNames, y => y.MapFrom(z => z.Products));
        }

    }
}