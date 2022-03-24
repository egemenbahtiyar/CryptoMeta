using CryptoMeta.DataAccess.Abstract;
using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoMeta.DataAccess.Concrete
{
    public class EfCoreBlogDal : EfCoreGenericRepository<Blog, CryptoMetaContext>, IBlogDal
    {
        public List<Blog> GetMyArticles(string UserId)
        {
            using (var context = new CryptoMetaContext())
            {
                return context.Set<Blog>().Where(x=>x.UserId==UserId).ToList();
            }
        }
    }
}