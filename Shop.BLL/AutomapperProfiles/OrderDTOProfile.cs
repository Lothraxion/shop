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
    class OrderDTOProfile:Profile
    {
        public OrderDTOProfile()
        {
            CreateMap<ProductDTO, string>().ConstructUsing(c => c.Name);
        }
    }
}
