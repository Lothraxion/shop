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
    public class SubSectionDTOProfile:Profile
    {
        public SubSectionDTOProfile()
        {

            CreateMap<ProductDTO, string>().ConstructUsing(n => n.Name);
            CreateMap<SubSection, SubSectionDTO>().ForMember(x => x.Products, y => y.MapFrom(z => z.Products)).ReverseMap();
        }
    }
}
