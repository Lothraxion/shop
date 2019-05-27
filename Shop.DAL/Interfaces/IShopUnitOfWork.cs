using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Interfaces
{
     public interface IShopUnitOfWork:IDisposable
    {

        IShopRepository<Category> CategoryRepository { get; }
        IShopRepository<Product> ProductRepository { get; }
        IShopRepository<Section> SectionRepository { get; }
        IShopRepository<SubSection> SubSectionRepository { get; }
        IShopRepository<User> UserRepository { get; }

        void CommtiChanges();
        void RejectChanges();
    }
}
