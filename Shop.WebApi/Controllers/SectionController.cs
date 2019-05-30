using AutoMapper;
using Shop.BLL.DTO;
using Shop.BLL.Interfaces;
using Show.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Show.WebApi.Controllers
{
    [RoutePrefix("api/Section")]
    public class SectionController : ApiController
    {
        ISectionService service;
        public SectionController(ISectionService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetSections()
        {
            var sectionsDTO = service.GetSections();
            var sectionsView = Mapper.Map<IEnumerable<SectionDTO>, List<SectionViewModel>>(sectionsDTO);
            return Ok(sectionsView);
        }
        [HttpPost]
        [Route("AddSection")]
        public IHttpActionResult AddCategory(SectionViewModel section)
        {
            var sectionDTO = Mapper.Map<SectionViewModel, SectionDTO>(section);
            service.AddSection(sectionDTO);
            return Ok();

        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            var sectionDTO = service.GetSection(id);
            var sectionsView = Mapper.Map<SectionDTO, SectionViewModel>(sectionDTO);
            return Ok(sectionsView);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            service.DeleteSection(id);
            return Ok();
        }
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Update(int id, SectionViewModel section)
        {
            var sectionDTO = Mapper.Map<SectionViewModel, SectionDTO>(section);
            service.UpdateSection(id, sectionDTO);
            return Ok();
        }





    }
}
