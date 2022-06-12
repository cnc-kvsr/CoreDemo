using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class
    {
        public void Delete(TEntity entity)
        {
            using var context = new Context();
            context.Remove(entity);
            context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            using var context = new Context();
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetByID(int id)
        {
            using var context = new Context();
            return context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            using var context = new Context();
            context.Add(entity);
            context.SaveChanges();
        }

        //public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        //{
        //    using var context = new Context();
        //    return context.Set<TEntity>().Where(filter).ToList();
        //}

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new Context();
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();

        }

        public void Update(TEntity entity)
        {
            using var context = new Context();
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
