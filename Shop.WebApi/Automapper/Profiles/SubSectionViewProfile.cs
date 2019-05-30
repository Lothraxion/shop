using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Shop.BLL.DTO;
using Show.WebApi.Models;

namespace Show.WebApi.Automapper.Profiles
{
    public class SubSectionViewProfile:Profile
    {
        public SubSectionViewProfile()
        {
            CreateMap<ProductDTO, string>().ConstructUsing(x => x.Name);
            CreateMap<SubSectionDTO, SubSectionViewModel>().ForMember(x => x.Products, y => y.MapFrom(z => z.Products)).ReverseMap();
        }
    }
}