using AutoMapper;
using Shop.BLL.DTO;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.AutomapperProfiles
{
    public class ProductDTOProfile:Profile
    {
        public ProductDTOProfile()
        {

            CreateMap<Product, ProductDTO>().ForMember(x => x.Price, y => y.MapFrom(z => z.Pirce))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
                .ForMember(x=>x.Sales,y=>y.MapFrom(z=>z.Sales)).ReverseMap();

        }
    }
}
