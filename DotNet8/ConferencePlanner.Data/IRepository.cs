using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConferencePlanner.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(object id);        
        void Insert(TEntity entity);

        void Delete(object id);

        IEnumerable<TEntity> Get();

        void Update(TEntity entityToUpdate);
    }
}