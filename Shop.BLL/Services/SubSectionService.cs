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
    public class SubSectionService : ISubSectionService
    {
        private readonly IShopUnitOfWork unitOfWork;
        public SubSectionService(IShopUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddSubSection(SubSectionDTO subSectionDTO)
        {
            var subsection = unitOfWork.SubSectionRepository.GetItemByExpression(n => n.Name.Equals(subSectionDTO.Name, StringComparison.OrdinalIgnoreCase));
            var section = unitOfWork.SectionRepository.GetItemByExpression(n => n.Name.Equals(subSectionDTO.SectionName, StringComparison.OrdinalIgnoreCase));
            if (subsection == null)
            {
                unitOfWork.SubSectionRepository.Create(new SubSection { Name = subSectionDTO.Name, Section = section });
                unitOfWork.CommtiChanges();
            }
            else throw new AlreadyExistingException("this Sub Section already existing");
        }

        public void DeleteSubSection(int? id)
        {
            var checkSubSection = unitOfWork.SubSectionRepository.GetItemById(id);
            if (checkSubSection == null)
                throw new NotExsitingException("this Sub Section is not existing");
            unitOfWork.SubSectionRepository.Delete(id);
            unitOfWork.CommtiChanges();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public SubSectionDTO GetSubSection(int? id)
        {
            var checkSubSection = unitOfWork.SubSectionRepository.GetItemById(id);
            if (checkSubSection == null)
                throw new NotExsitingException("this Sub Section is not existing");
            var subSectionDTO = Mapper.Map<SubSection, SubSectionDTO>(checkSubSection);
            return subSectionDTO;
        }

        public IEnumerable<SubSectionDTO> GetSubSections()
        {
            var subSections = unitOfWork.SubSectionRepository.GetItemList();
            var subSectionsDTO = Mapper.Map<IEnumerable<SubSection>, List<SubSectionDTO>>(subSections);
            return subSectionsDTO;
        }

        public void UpdateSubSection(int? id, SubSectionDTO subSection)
        {
            var checkSubSection = unitOfWork.SubSectionRepository.GetItemById(id);
            if (checkSubSection == null)
                throw new NotExsitingException("this  Sub Section is not existing");
            checkSubSection.Name = subSection.Name;
            unitOfWork.SubSectionRepository.Update(checkSubSection);
            unitOfWork.CommtiChanges();
        }
    }
}
