using Microsoft.EntityFrameworkCore;
using monovi.bookstore.dal;
using monovi.bookstore.dal.Repository.IRepository;
using monovi.bookstore.utility.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace monovi.bookstore.dal.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            PrepareDefaultCreatedFields(entity);
            dbSet.Add(entity);
        }

        private void PrepareDefaultCreatedFields(T entity)
        {
            PropertyInfo pInfo = entity.GetType().GetProperty("CreatedUserID");
            if (pInfo != null)
                pInfo.SetValue(entity, AccountHelper.GetDefaultAccountID());
            pInfo = entity.GetType().GetProperty("CreatedDate");
            if (pInfo != null)
                pInfo.SetValue(entity, DateTime.Now);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = CreateQueryAccTo(filter, includeProperties);

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        private IQueryable<T> CreateQueryAccTo(Expression<Func<T, bool>> filter, string includeProperties)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(","))
                {
                    query = query.Include(property);
                }
            }

            return query;
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = CreateQueryAccTo(filter, includeProperties);
            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T entity = dbSet.Find(id);
            Remove(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
