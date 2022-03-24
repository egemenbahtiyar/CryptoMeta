using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMeta.DataAccess.Abstract
{
    public interface IBlogDal:IRepository<Blog>
    {
        public List<Blog> GetMyArticles(string UserId);
    }
}
