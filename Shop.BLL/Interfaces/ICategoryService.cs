using Shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
    public interface ICategoryService:IDisposable
    {
        IEnumerable<CategoryDTO> GetCategories();
        CategoryDTO GetCategory(int? id);
        void UpdateCategory(int? id, CategoryDTO category);
        void AddCategory(CategoryDTO category);
        void DeleteCategory(int? id);
    }
}
