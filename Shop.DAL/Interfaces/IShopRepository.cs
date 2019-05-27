using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Interfaces
{
    public interface IShopRepository<T>:IDisposable 
        where T :class
    {
        IEnumerable<T> GetItemList();
        T GetItemById(int? Id);
        void Create(T item);
        void Delete(int? id);
        void Update(T item);
        void Delete(T item);
        void Save();
        IEnumerable<T> GetItemListByWhere(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetItemListByInclude(Expression<Func<T, bool>> filter);
        T GetItemByExpression(Expression<Func<T, bool>> filter);

    }
}
