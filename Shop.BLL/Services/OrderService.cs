using Shop.BLL.DTO;
using Shop.BLL.Interfaces;
using Shop.DAL.Interfaces;
using Shop.DAL.UnitOfWork;
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
  public class OrderService : IOrderService
    {
        private readonly IShopUnitOfWork unitOfWork;

        public OrderService(IShopUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddProductToCart(ProductAddModel product)
        {
            try
            {
                var user = unitOfWork.UserRepository.GetItemByExpression(x => x.Name.Equals(product.UserName, StringComparison.OrdinalIgnoreCase));
                if (user == null)
                {
                    unitOfWork.UserRepository.Create(new DAL.Entities.User() { Name = product.UserName, Cart = new OrderCart() });
                    unitOfWork.UserRepository.Save();
                }
                user = unitOfWork.UserRepository.GetItemByExpression(x => x.Name.Equals(product.UserName, StringComparison.OrdinalIgnoreCase));
                if (user.Cart == null)
                {
                    unitOfWork.ProductCartRepository.Create(new DAL.Entities.OrderCart() { User = user });
                    unitOfWork.ProductCartRepository.Save();
                }
                var productToAdd = unitOfWork.ProductRepository.GetItemById(product.ProductId);
                if (productToAdd == null)
                    throw new NotExsitinException("Product not Existing");
                if (productToAdd.Amount < product.Amount)
                    throw new InvalidArgumentException("Product have not enough amount");
                user.Cart.Products.Add(productToAdd);
                user.Cart.TotalPrice += productToAdd.Pirce * product.Amount;
                productToAdd.Amount -= product.Amount;
                productToAdd.Sales += product.Amount;
                unitOfWork.ProductRepository.Update(productToAdd);
                unitOfWork.ProductCartRepository.Update(user.Cart);
                unitOfWork.CommtiChanges();
            }
            catch (NotExsitinException ex)
            {
                throw new AddingException(ex.Message);
            }
            catch (InvalidArgumentException ex)
            {
                throw new AddingException(ex.Message);
            }
        }
        public OrderCartDTO GetOrderInfo(string UserName)
        {
            var order = unitOfWork.ProductCartRepository.GetItemByExpression(x => x.User.Name.Equals(UserName, StringComparison.OrdinalIgnoreCase));
            return Mapper.Map<OrderCart, OrderCartDTO>(order);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
