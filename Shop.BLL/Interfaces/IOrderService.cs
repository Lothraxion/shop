using Shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
 public interface IOrderService:IDisposable
    {
        void AddProductToCart(ProductAddModel product);
        OrderCartDTO GetOrderInfo(string UserName);
    }
}
