using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ConferencePlanner.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class    
    {
        internal ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public virtual TEntity GetByID(object id)
        {
            return context.Find<TEntity>(id);
        }

        public virtual void Insert(TEntity entity)
        {
            context.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = context.Find<TEntity>(id);
            Delete(entityToDelete);
        }

        public IEnumerable<TEntity> Get()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Update(TEntity entityToUpdate)
        {
            context.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }        
    }
}
