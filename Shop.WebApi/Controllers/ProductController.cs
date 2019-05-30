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
using Show.WebApi.Models;
using AutoMapper;
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

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            service.Delete(id);
            return Ok();

        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetProduct(int id)
        {
            var productdto= service.GetProduct(id);
            var productView =Mapper.Map<ProductDTO, ProductViewModel>(productdto);
            return Ok(productView);

        }
        [Route("")]
        [Authorize]
        //public IHttpActionResult Get()
        //{
        //    return Ok(User.Identity.Name + User.IsInRole("user"));
        //}
        public IHttpActionResult GetProducts()
        {
            var posts = service.GetProducts();
            return Ok(posts);
        }
        [HttpPost]
        [Route("AddProduct")]
        public IHttpActionResult AddProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productdto = Mapper.Map<ProductViewModel, ProductDTO>(product);
                service.Add(productdto);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        [Route("UpdateProduct/{id:int}")]
        public IHttpActionResult UpdateProduct(int id, ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productdto = Mapper.Map<ProductViewModel, ProductDTO>(product);
                service.Update(id, productdto);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }


        }
        [Route("InRange")]
        //  [AllowAnonymous]
        [Authorize]
        public IHttpActionResult GetProductsinRange(ProductInRangeModel range)
        {
            if (ModelState.IsValid)
            {
                var posts = service.GetProductsInRange(range.bot, range.top);
                var postsView = Mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(posts);
                return Ok(postsView);
            }
            else
                return BadRequest(ModelState);

        }
        [Route("ByName")]
        [Authorize(Roles = "Admin,Manager")]
        public IHttpActionResult GetProductsByName([FromUri] string Name)
        {
            var products = service.GetProductsThatContainsWord(Name);
            return Ok(products);
        }
       
    }
}
