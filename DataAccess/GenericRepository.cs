using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly FStoreDBContext _context = null;
        protected readonly DbSet<T> _dbSet = null;
        public GenericRepository()
        {
            this._context = new FStoreDBContext();
            this._dbSet = _context.Set<T>();
        }
        public GenericRepository(FStoreDBContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<T>();
        }

        public void Delete(object id)
        {
            T existing = this._dbSet.Find(id);
            if (existing != null)
            {
                this._dbSet.Remove(existing);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return this._dbSet.ToList();
        }

        public T GetById(object id)
        {
            return this._dbSet.Find(id);
        }

        public void Insert(T obj)
        {
            this._dbSet.Add(obj);
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        public void Update(T obj)
        {
            this._dbSet.Attach(obj);
            this._context.Entry(obj).State = EntityState.Modified;
        }
    }
}
