using CryptoMeta.DataAccess.Abstract;
using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CryptoMeta.DataAccess.Concrete
{
    public class EfCoreBlogDal : IBlogRepository
    {
        public void Create(Blogs entitiy)
        {
            throw new NotImplementedException();
        }

        public void Delete(Blogs entitiy)
        {
            throw new NotImplementedException();
        }

        public List<Blogs> GetAll(Expression<Func<Blogs, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Blogs GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Blogs entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
