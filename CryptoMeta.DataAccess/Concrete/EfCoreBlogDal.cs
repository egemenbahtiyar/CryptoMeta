using CryptoMeta.DataAccess.Abstract;
using CryptoMeta.Entities;
using Microsoft.EntityFrameworkCore;
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
                return context.Blogs.Include(x=>x.Category).Include(x=>x.User).Where(x=>x.UserId==UserId).ToList();
            }
        }
    }
}