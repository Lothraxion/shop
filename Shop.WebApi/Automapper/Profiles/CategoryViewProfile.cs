using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Shop.BLL.DTO;
using Show.WebApi.Models;

namespace Show.WebApi.Automapper.Profiles
{
    public class CategoryViewProfile:Profile
    {
        public CategoryViewProfile()
        {
            CreateMap<SectionDTO, string>().ConstructUsing(x => x.Name);
            CreateMap<CategoryDTO, CategoryViewModel>().ForMember(x => x.Name, y => y.MapFrom(z => z.Name)).ReverseMap();
        }
    }
}