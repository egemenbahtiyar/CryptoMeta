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
        void Create (T entitiy);
        void Delete (T entitiy);
        void Update (T entitiy);
    }
}
