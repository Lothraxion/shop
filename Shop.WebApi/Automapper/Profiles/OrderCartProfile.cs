using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Shop.BLL.DTO;
using Show.WebApi.Models;

namespace Show.WebApi.Automapper.Profiles
{
    public class OrderCartProfile:Profile
    {
        public OrderCartProfile()
        {
            //CreateMap<ProductAddModel, AddToOrderViewModel>().ForMember(x=>x.UserName=User)
        }
    }
}