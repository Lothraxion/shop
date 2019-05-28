using Shop.DAL.DB;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Repository
{
   public class ShopRepository<T> : IShopRepository<T> where T : class
    {
        private EShopContext context = null;
        private IDbSet<T> table => context.Set<T>();

        public ShopRepository(EShopContext context)
        {
            this.context = context;
        }

        public void Create(T item)
        {
            table.Add(item);
        }

        public void Delete(T item)
        {
            table.Remove(item);
        }

        public void Delete(int? id)
        {
           T temp= table.Find(id);
            table.Remove(temp);
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public T GetItemByExpression(Expression<Func<T, bool>> expression)
        {
            return table.FirstOrDefault(expression);
        }

        public T GetItemById(int? Id)
        {
            return table.Find(Id);
        }

        public IEnumerable<T> GetItemList()
        {
            return table.ToList();
        }

        public IEnumerable<T> GetItemListByInclude(Expression<Func<T, bool>> expression)
        {
            return table.Include(expression).ToList();
        }

        public IEnumerable<T> GetItemListByWhere(Expression<Func<T, bool>> expression)
        {
            return table.Where(expression).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T item)
        {
            table.Attach(item);
            context.Entry(item).State = EntityState.Modified;
        }

       
    }
}
