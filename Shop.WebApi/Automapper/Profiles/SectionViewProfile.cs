using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Shop.BLL.DTO;
using Show.WebApi.Models;

namespace Show.WebApi.Automapper.Profiles
{
    public class SectionViewProfile:Profile
    {
        public SectionViewProfile()
        {
            CreateMap<SubSectionDTO, string>().ConstructUsing(c => c.Name);
            CreateMap<SectionDTO, SectionViewModel>().ForMember(x=>x.SubSections,y=>y.MapFrom(z=>z.SubSections)).ReverseMap();
        }
    }
}