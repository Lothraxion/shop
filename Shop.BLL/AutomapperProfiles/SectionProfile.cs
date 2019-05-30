using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shop.BLL.DTO;
using Shop.DAL.Entities;

namespace Shop.BLL.AutomapperProfiles
{
    public class SectionProfile:Profile
    {
        public SectionProfile()
        {
            CreateMap<Category, string>().ConstructUsing(c => c.Name);
            CreateMap<Section, SectionDTO>().ForMember(c => c.CategoryName, y => y.MapFrom(z => z.Category));
        }
    }
}
