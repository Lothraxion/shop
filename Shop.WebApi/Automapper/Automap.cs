using Shop.BLL.AutomapperProfiles;
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

              



                cfg.AddProfile<ProductDTOProfile>();
                //cfg.CreateMap<Tag, string>().ConstructUsing(c => c.Name);
                //cfg.CreateMap<Category, string>().ConstructUsing(c => c.Name);
                //cfg.CreateMap<Post, PostDTO>()
                //.ForMember(c => c.tags, y => y.MapFrom(z => z.Tags))
                //.ForMember(c => c.CategoryName, y => y.MapFrom(z => z.Category));


            });
        }
    }
}