using Shop.BLL.AutomapperProfiles;
using Show.WebApi.Automapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Show.WebApi.Automapper
{
    public class Automap
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<OrderViewModelProfile>();
                cfg.AddProfile<ProductDTOProfile>();
                cfg.AddProfile<ProductViewProfile>();
             
            });
        }
    }
}