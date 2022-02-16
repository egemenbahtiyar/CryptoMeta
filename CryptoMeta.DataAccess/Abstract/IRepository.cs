using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CryptoMeta.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        T GetbyId(int id);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Create (T entity);
        void Delete (T entity);
        void Update (T entity);
    }
}
