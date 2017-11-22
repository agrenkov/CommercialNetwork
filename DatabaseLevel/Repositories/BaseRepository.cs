using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using DatabaseLevel.Interfaces;

namespace DatabaseLevel.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DatabaseContext Context;

        public BaseRepository(DatabaseContext context)
        {
            Context = context;
        }

        public IQueryable<T> GetAllQuery()
        {
            return Context.Set<T>().AsQueryable();
        }

        public ICollection<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).AsQueryable();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return Context.Set<T>().SingleOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await Context.Set<T>().SingleOrDefaultAsync(match);
        }

        public T FindByKey(params object[] keys)
        {
            return Context.Set<T>().Find(keys);
        }

        public async Task<T> FindByKeyAsync(params object[] keys)
        {
            return await Context.Set<T>().FindAsync(keys);
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Count(predicate) > 0;
        }



        public T Add(T t)
        {
            return Context.Set<T>().Add(t);
        }

        public IEnumerable<T> AddRange(IEnumerable<T> t)
        {
            return Context.Set<T>().AddRange(t);
        }

        public void RemoveRange(IEnumerable<T> t)
        {
            Context.Set<T>().RemoveRange(t);
        }

        public void Delete(T t)
        {
            Context.Set<T>().Remove(t);
        }

        public void Update(T t)
        {
            var entry = Context.Entry(t);
            Context.Set<T>().Attach(t);
            entry.State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }




        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }
    }
}
