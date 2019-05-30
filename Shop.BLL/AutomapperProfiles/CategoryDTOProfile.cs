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
    public class CategoryDTOProfile:Profile
    {
        public CategoryDTOProfile()
        {
            CreateMap<Category, CategoryDTO>();
        }

    }
}
