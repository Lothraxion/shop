using Shop.BLL.DTO;
using Shop.BLL.Interfaces;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shop.DAL.Entities;
using Shop.BLL.Exceptions;

namespace Shop.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IShopUnitOfWork unitOfWork;
        public CategoryService(IShopUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddCategory(CategoryDTO categoryDTO)
        {
            var category =unitOfWork.CategoryRepository.GetItemByExpression(n => n.Name.Equals(categoryDTO.Name, StringComparison.OrdinalIgnoreCase));
            if (category == null)
            {
                unitOfWork.CategoryRepository.Create(new Category { Name = categoryDTO.Name });
                unitOfWork.CommtiChanges();
            }
            else throw new AlreadyExistingException("this Category already existing");
        }

        public void DeleteCategory(int? id)
        {
            var checkCategory = unitOfWork.CategoryRepository.GetItemById(id);
            if (checkCategory == null)
                throw new NotExsitingException("this category is not existing");
            unitOfWork.CategoryRepository.Delete(id);
            unitOfWork.CommtiChanges();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var categories = unitOfWork.CategoryRepository.GetItemList();
            var categoriesDTO= Mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(categories);
            return categoriesDTO;

        }

        public CategoryDTO GetCategory(int? id)
        {
            var checkCategory = unitOfWork.CategoryRepository.GetItemById(id);
            if (checkCategory == null)
                throw new NotExsitingException("this category is not existing");
            var categoryDTO = Mapper.Map<Category, CategoryDTO>(checkCategory);
            return categoryDTO;
        }

        public void UpdateCategory(int? id, CategoryDTO category)
        {
            var categoryCheck = unitOfWork.CategoryRepository.GetItemById(id);
            if(categoryCheck==null)
                throw new NotExsitingException("this category is not existing");
            categoryCheck.Name = category.Name;
            unitOfWork.CategoryRepository.Update(categoryCheck);
            unitOfWork.CommtiChanges();
        }
    }
}
