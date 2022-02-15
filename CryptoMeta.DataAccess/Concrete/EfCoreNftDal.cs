using CryptoMeta.DataAccess.Abstract;
using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CryptoMeta.DataAccess.Concrete
{
    public class EfCoreNftDal : INftRepository
    {
        public void Create(Nfts entitiy)
        {
            throw new NotImplementedException();
        }

        public void Delete(Nfts entitiy)
        {
            throw new NotImplementedException();
        }

        public List<Nfts> GetAll(Expression<Func<Nfts, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Nfts GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Nfts entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
