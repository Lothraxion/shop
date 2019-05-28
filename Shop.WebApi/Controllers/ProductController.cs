using Shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shop.BLL.Interfaces;
using System.Security.Claims;
using Shop.DAL.Constants;

namespace Show.WebApi.Controllers
{
    [RoutePrefix("api/product")]
    [Authorize]
    public class ProductController : ApiController
    {
        IProductService service;

       public ProductController(IProductService service)
        {
            this.service = service;
        }

    
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(service.GetProducts());
        }
        //public IEnumerable<ProductDTO> GetProducts()
        //{
        //    var posts = service.GetProducts();
        //    return posts;
        //}
        
        [Route("InRange")]
        //  [AllowAnonymous]
        [Authorize(Roles = "User")]
        public IEnumerable<ProductDTO> GetProductsinRange([FromUri]int bot, [FromUri]int top)
        {
            var posts = service.GetProductsInRange(bot, top);
            return posts;

        }
        [Route("ByName")]
        [AllowAnonymous]
        public IEnumerable<ProductDTO> GetProductsByName([FromUri] string Name)
        {
            return service.GetProductsThatContainsWord(Name);
        }
    }
}
