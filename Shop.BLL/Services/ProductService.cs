using Shop.BLL.DTO;
using Shop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DAL.Interfaces;
using AutoMapper;
using Shop.DAL.Entities;
using Shop.BLL.Exceptions;

namespace Shop.BLL.Services
{
   public class ProductService : IProductService
    {
        public IShopUnitOfWork unitOfWork { get; private set; }
        public ProductService(IShopUnitOfWork unit)
        {
            this.unitOfWork = unit;
        }
        public void Add(ProductDTO product)
        {
            var category = unitOfWork.CategoryRepository.GetItemByExpression(n => n.Name.Equals(product.CategoryName, StringComparison.OrdinalIgnoreCase));
            if (category == null)
            {
                throw new NotExsitinException("Category does not existing");
            }
            var section = unitOfWork.SectionRepository.GetItemByExpression(n => n.Name.Equals(product.SectionName, StringComparison.OrdinalIgnoreCase));
            if (section == null)
            {
                throw new NotExsitinException("Section does not existing");
            }
            var subsection = unitOfWork.SubSectionRepository.GetItemByExpression(n => n.Name.Equals(product.SubSectionName, StringComparison.OrdinalIgnoreCase));
            if (subsection == null)
            {
                throw new NotExsitinException("Subsection does not existing");
            }
            Product tempProduct = Mapper.Map<ProductDTO, Product>(product);
            tempProduct.Category = category;
            tempProduct.Amount = product.Amount;
            tempProduct.Section = section;
            tempProduct.SubSection = subsection;
            unitOfWork.ProductRepository.Create(tempProduct);
            unitOfWork.CommtiChanges();
        }

        public void Delete(int? id)
        {

            unitOfWork.ProductRepository.Delete(id);
            unitOfWork.CommtiChanges();

        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
        public ProductDTO GetProduct(int? id)
        {
            Product product=unitOfWork.ProductRepository.GetItemById(id);
            return Mapper.Map<Product, ProductDTO>(product);
        }

        public ProductDTO GetProductByName(string name)
        {
            Product product = unitOfWork.ProductRepository.GetItemByExpression(n=>n.Name.Equals(name));
            return Mapper.Map<Product, ProductDTO>(product);
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItemList();
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(products);
        }

        public IEnumerable<ProductDTO> GetProductsInRange(int bot, int top)
        {
            
            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItemListByWhere(p=>p.Pirce>=bot&&p.Pirce<=top);
            var sortedProducts = products.OrderBy(p => p.Pirce);
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(sortedProducts);
        }
        
        public IEnumerable<ProductDTO> GetProductsThatContainsWord(string word)
        {
            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItemListByWhere(n => n.Name.Contains(word));
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(products);

        }
        public IEnumerable<ProductDTO> GetProductsSorted()
        {
            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItemList();
            var sortedProducts = products.OrderBy(p => p.Pirce);
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(sortedProducts);
        }
        public void AddToOrder(int? id, int Amount)
        {
            var tempProduct = unitOfWork.ProductRepository.GetItemById(id);
            if (Amount < 0)
                throw new Exception();
            if (tempProduct.Amount < Amount)
                throw new Exception();
            tempProduct.Amount -= Amount;
            tempProduct.Sales += Amount;
            
        }

        public void Update(int? id, ProductDTO product)
        {
            var tempProduct = unitOfWork.ProductRepository.GetItemById(id);
            var tempCategory= unitOfWork.CategoryRepository.GetItemByExpression(n => n.Name == product.CategoryName);
            var tempSectiong =unitOfWork.SectionRepository.GetItemByExpression(n => n.Name == product.CategoryName);
            tempProduct.Amount = product.Amount;
            tempProduct.Name = product.Name;
            tempProduct.Pirce = product.Price;
            tempProduct.Сharacteristics = product.Сharacteristics;
            tempProduct.Category = tempCategory;
            tempProduct.CategoryId = tempCategory.Id;
        }
    }
}
