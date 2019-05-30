using Shop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Shop.BLL.DTO;
using Show.WebApi.Models;

namespace Show.WebApi.Controllers
{

    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        ICategoryService service;
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetCategories()
        {
            var categoriesDTO = service.GetCategories();
            var categoriesView = Mapper.Map<IEnumerable<CategoryDTO>, List<CategoryViewModel>>(categoriesDTO);
            return Ok(categoriesView);
        }
        [HttpPost]
        [Route("AddCategory")]
        public IHttpActionResult AddCategory(CategoryViewModel category)
        {
            var categoryDTO = Mapper.Map<CategoryViewModel, CategoryDTO>(category);
            service.AddCategory(categoryDTO);
            return Ok();

        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            var categoryDTO = service.GetCategory(id);
            var categoryView=  Mapper.Map<CategoryDTO, CategoryViewModel>(categoryDTO);
            return Ok(categoryView);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            service.DeleteCategory(id);
            return Ok();
        }
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Update(int id, CategoryViewModel category)
        {
            var categorydto = Mapper.Map<CategoryViewModel, CategoryDTO>(category);
            service.UpdateCategory(id, categorydto);
            return Ok();
        }
    }
}
