using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CryptoMeta.Business.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetMyArticles(string UserId);
        Blog GetbyId(int id);
        List<Blog> GetAll();
        void Create(Blog entity);
        void Delete(Blog entity);
        void Update(Blog entity);
    }
}
