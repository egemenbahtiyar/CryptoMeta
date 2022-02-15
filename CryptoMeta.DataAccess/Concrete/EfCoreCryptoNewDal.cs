using CryptoMeta.DataAccess.Abstract;
using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CryptoMeta.DataAccess.Concrete
{
    public class EfCoreCryptoNewDal : ICryptoNewRepository
    {
        public void Create(CryptoNews entitiy)
        {
            throw new NotImplementedException();
        }

        public void Delete(CryptoNews entitiy)
        {
            throw new NotImplementedException();
        }

        public List<CryptoNews> GetAll(Expression<Func<CryptoNews, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CryptoNews GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CryptoNews entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
