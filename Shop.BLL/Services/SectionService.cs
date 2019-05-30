using AutoMapper;
using Shop.BLL.DTO;
using Shop.BLL.Exceptions;
using Shop.BLL.Interfaces;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class SectionService:ISectionService
    {
        private readonly IShopUnitOfWork unitOfWork;
        public SectionService(IShopUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddSection(SectionDTO sectionDTO)
        {
            var section = unitOfWork.SectionRepository.GetItemByExpression(n => n.Name.Equals(sectionDTO.Name, StringComparison.OrdinalIgnoreCase));
            var category = unitOfWork.CategoryRepository.GetItemByExpression(n => n.Name.Equals(sectionDTO.CategoryName, StringComparison.OrdinalIgnoreCase));
            if (section == null)
            {
                unitOfWork.SectionRepository.Create(new Section { Name = sectionDTO.Name,Category=category});
                unitOfWork.CommtiChanges();
            }
            else throw new AlreadyExistingException("this Section already existing");
        }

        public void DeleteSection(int? id)
        {
            var checkSection= unitOfWork.SectionRepository.GetItemById(id);
            if (checkSection == null)
                throw new NotExsitingException("this section is not existing");
            unitOfWork.SectionRepository.Delete(id);
            unitOfWork.CommtiChanges();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public SectionDTO GetSection(int? id)
        {
            var checkSection = unitOfWork.SectionRepository.GetItemById(id);
            if (checkSection == null)
                throw new NotExsitingException("this section is not existing");
            var sectionDTO = Mapper.Map<Section, SectionDTO>(checkSection);
            return sectionDTO;
        }

        public IEnumerable<SectionDTO> GetSections()
        {
            var sections = unitOfWork.SectionRepository.GetItemList();
            var sectionsDTO = Mapper.Map<IEnumerable<Section>, List<SectionDTO>>(sections);
            return sectionsDTO;
        }

        public void UpdateSection(int? id, SectionDTO section)
        {
            var checkSection = unitOfWork.SectionRepository.GetItemById(id);
            if (checkSection == null)
                throw new NotExsitingException("this section is not existing");
            checkSection.Name = section.Name;
            unitOfWork.SectionRepository.Update(checkSection);
            unitOfWork.CommtiChanges();
        }
    }
}
