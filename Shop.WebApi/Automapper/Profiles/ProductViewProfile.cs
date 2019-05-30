using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Shop.BLL.DTO;
using Show.WebApi.Models;

namespace Show.WebApi.Automapper.Profiles
{
    public class ProductViewProfile:Profile
    {
        public ProductViewProfile()
        {
            CreateMap<ProductViewModel, ProductDTO>().ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x=>x.Sales,y=>y.MapFrom(z=>z.Sales)).ReverseMap();
        }
    }
}