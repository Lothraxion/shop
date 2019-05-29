using Shop.DAL.DB;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using Shop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.UnitOfWork
{
    public class ShopUnitOfWork : IShopUnitOfWork
    {
        private readonly EShopContext _eShopContext;

        #region Repositories


        public IShopRepository<Category> CategoryRepository =>
            new ShopRepository<Category>(_eShopContext);

        public IShopRepository<Product> ProductRepository =>
            new ShopRepository<Product>(_eShopContext);

        public IShopRepository<Section> SectionRepository =>
            new ShopRepository<Section>(_eShopContext);

        public IShopRepository<SubSection> SubSectionRepository =>
            new ShopRepository<SubSection>(_eShopContext);

        public IShopRepository<User> UserRepository =>
            new ShopRepository<User>(_eShopContext);

        public IShopRepository<OrderCart> ProductCartRepository => 
            new ShopRepository<OrderCart>(_eShopContext);
        #endregion

        public ShopUnitOfWork(string ConnectionString)
        {
            _eShopContext = new EShopContext(ConnectionString);
        }

        public void CommtiChanges()
        {
            _eShopContext.SaveChanges();
        }

        public void Dispose()
        {
            _eShopContext.Dispose();
        }

        public void RejectChanges()
        {
            foreach (var entry in _eShopContext.ChangeTracker.Entries()
               .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}

