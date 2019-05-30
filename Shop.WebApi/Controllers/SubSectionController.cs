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
    [RoutePrefix("api/SubSection")]
    public class SubSectionController : ApiController
    {
        ISubSectionService service;
        public SubSectionController(ISubSectionService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetSections()
        {
            var SubsectionsDTO = service.GetSubSections();
            var SubsectionsView = Mapper.Map<IEnumerable<SubSectionDTO>, List<SubSectionViewModel>>(SubsectionsDTO);
            return Ok(SubsectionsView);
        }
        [HttpPost]
        [Route("AddSubSection")]
        [Authorize(Roles = "Admin,Manager")]
        public IHttpActionResult AddSubSection(SubSectionViewModel subSection)
        {
            var SubSectionDTO = Mapper.Map<SubSectionViewModel, SubSectionDTO>(subSection);
            service.AddSubSection(SubSectionDTO);
            return Ok();

        }
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetSubSectionyById(int id)
        {
            var subSectionDTO = service.GetSubSection(id);
            var subSectionsView = Mapper.Map<SubSectionDTO, SubSectionViewModel>(subSectionDTO);
            return Ok(subSectionsView);
        }
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin,Manager")]
        public IHttpActionResult DeleteSubSection(int id)
        {
            service.DeleteSubSection(id);
            return Ok();
        }
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin,Manager")]
        public IHttpActionResult Update(int id, SubSectionViewModel subSection)
        {
            var subSectionDTO = Mapper.Map<SubSectionViewModel, SubSectionDTO>(subSection);
            service.UpdateSubSection(id, subSectionDTO);
            return Ok();
        }
    }
}
