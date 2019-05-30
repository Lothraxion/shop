using Shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
  public  interface IProductService:IDisposable
    {
        void Add(ProductDTO product);
        void Delete(int? id);
        void Update(int? id, ProductDTO product);
        ProductDTO GetProduct(int? id);
        IEnumerable<ProductDTO> GetProducts();
        IEnumerable<ProductDTO> GetProductsInRange(int bot, int top);
      //ProductDTO GetProductByName(string name);
        IEnumerable<ProductDTO> GetProductsSorted();
        IEnumerable<ProductDTO> GetProductsThatContainsWord(string word);

    }
}
