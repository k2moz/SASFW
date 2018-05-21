using BusinessLayer.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Impl
{
    public class EFCustumRepository<T> : ICustumRepository<T> where T : class
    {
        private EFDBContext context;
        Microsoft.EntityFrameworkCore.DbSet<T> _dbSet;

        public EFCustumRepository(EFDBContext context)
        {
            this.context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAllItems()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public T GetFirstOrDefault(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(predicate);
        }

        public T GetItemById(int itemId)
        {
            return _dbSet.Find(itemId);
        }


        public void CreateItem(T item)
        {
            _dbSet.Add(item);
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public void UpdateItem(T item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteItem(T item)
        {
            _dbSet.Remove(item);
            context.SaveChanges();
        }

       
    }
}
