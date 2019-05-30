using Shop.BLL.Interfaces;
using Show.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Shop.BLL.DTO;
using System.Web.Security;
using Shop.BLL.Exceptions;

namespace Show.WebApi.Controllers
{
    [RoutePrefix("api/order")]
    [Authorize(Roles = "Admin,Manager,User")]
    public class OrderController : ApiController
    {
        IOrderService service;

        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetOrderInfo()
        {
            var order = service.GetOrderInfo(User.Identity.Name);
            var map = Mapper.Map<OrderCartDTO, OrderViewModel>(order);
            return Ok(map);
        }
        [HttpPost]
        [Route("AddProduct")]
        public IHttpActionResult AddProductToOrder(AddToOrderViewModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    product.UserName = User.Identity.Name;
                    Mapper.Map<AddToOrderViewModel, ProductAddModel>(product);
                    service.AddProductToCart(Mapper.Map<AddToOrderViewModel, ProductAddModel>(product));
                    return Ok();
                }
                catch (AddingException)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent(string.Format("Cant't add ProductId:{0} to order", product.ProductId)),
                        ReasonPhrase = "Cant't add Product"
                    };
                    throw new HttpResponseException(resp);
                }
            }
            else return BadRequest(ModelState);

        }

    }
}
