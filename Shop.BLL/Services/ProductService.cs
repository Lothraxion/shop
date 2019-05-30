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
            var section = unitOfWork.SectionRepository.GetItemByExpression(n => n.Name.Equals(product.SectionName, StringComparison.OrdinalIgnoreCase));
            var subsection = unitOfWork.SubSectionRepository.GetItemByExpression(n => n.Name.Equals(product.SubSectionName, StringComparison.OrdinalIgnoreCase));
            Product tempProduct = Mapper.Map<ProductDTO, Product>(product);
            var check = unitOfWork.ProductRepository.GetItemByExpression(n => n.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase));
            if (check == null)
            {
                tempProduct.Category = category ?? throw new NotExsitingException("Category does not existing");
                tempProduct.Amount = product.Amount;
                tempProduct.Section = section ?? throw new NotExsitingException("Section does not existing");
                tempProduct.SubSection = subsection ?? throw new NotExsitingException("Subsection does not existing");
                unitOfWork.ProductRepository.Create(tempProduct);
                unitOfWork.CommtiChanges();
            }
            else throw new AlreadyExistingException("Product already existing");
        }

        public void Delete(int? id)
        {
            var checkproduct = unitOfWork.ProductCartRepository.GetItemById(id);
            if (checkproduct != null)
            {
                unitOfWork.ProductRepository.Delete(id);
                unitOfWork.CommtiChanges();
            }
            else throw new NotExsitingException("Product Does not existing");
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
        public ProductDTO GetProduct(int? id)
        {
            var checkproduct = unitOfWork.ProductCartRepository.GetItemById(id);
            if (checkproduct != null)
            {
                Product product = unitOfWork.ProductRepository.GetItemById(id);
                return Mapper.Map<Product, ProductDTO>(product);
            }
            else throw new NotExsitingException("Product Does not existing");
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItemList();
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(products);
        }

        public IEnumerable<ProductDTO> GetProductsInRange(int bot, int top)
        {
            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItemListByWhere(p=>p.Pirce>=bot&&p.Pirce<=top);
            if (products == null)
                throw new NotExsitingException("Such products not existing");
            var sortedProducts = products.OrderBy(p => p.Pirce);
            var mappedProducts = Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(sortedProducts);
            return mappedProducts;
        }
        
        public IEnumerable<ProductDTO> GetProductsThatContainsWord(string word)
        {
            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItemListByWhere(n => n.Name.Contains(word));
            if (products == null)
                throw new NotExsitingException("this product not existing");
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(products);

        }
        public IEnumerable<ProductDTO> GetProductsSorted()
        {
            IEnumerable<Product> products = unitOfWork.ProductRepository.GetItemList();
            var sortedProducts = products.OrderBy(p => p.Pirce);
            return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(sortedProducts);
        }
       

        public void Update(int? id, ProductDTO product)
        {
            var tempProduct = unitOfWork.ProductRepository.GetItemById(id);
            if (tempProduct == null)
                throw new NotExsitingException("this product not existing");
            var tempCategory= unitOfWork.CategoryRepository.GetItemByExpression(n => n.Name.Equals(product.CategoryName, StringComparison.OrdinalIgnoreCase));
            var tempSection =unitOfWork.SectionRepository.GetItemByExpression(n => n.Name.Equals(product.SectionName, StringComparison.OrdinalIgnoreCase));
            var tempSubSection = unitOfWork.SubSectionRepository.GetItemByExpression(n => n.Name.Equals(product.SubSectionName, StringComparison.OrdinalIgnoreCase));
            var checkDublicateProduct = unitOfWork.ProductRepository.GetItemByExpression(n => n.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase));
            if (checkDublicateProduct == null|| tempProduct.Name.Equals(product.Name,StringComparison.OrdinalIgnoreCase))
            {
                tempProduct.Amount = product.Amount;
                tempProduct.Name = product.Name;
                tempProduct.Pirce = product.Price;
                tempProduct.Сharacteristics = product.Сharacteristics;
                tempProduct.Category = tempCategory;
                tempProduct.CategoryId = tempCategory.Id;
                tempProduct.Section = tempSection;
                tempProduct.SubSection = tempSubSection;
                unitOfWork.ProductRepository.Update(tempProduct);
                unitOfWork.CommtiChanges();
            }
            else throw new AlreadyExistingException("product with this name is already in database");
        }
    }
}
