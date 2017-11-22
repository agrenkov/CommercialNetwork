using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DatabaseLevel.Interfaces
{
    public interface IBaseRepository<T> : IDisposable
    {
        IQueryable<T> GetAllQuery();
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        Task<T> FindByKeyAsync(params object[] keys);
        bool Contains(Expression<Func<T, bool>> predicate);
        T FindByKey(params object[] keys);
        T Add(T t);
        IEnumerable<T> AddRange(IEnumerable<T> t);
        void RemoveRange(IEnumerable<T> t);
        void Delete(T t);
        void Update(T t);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
