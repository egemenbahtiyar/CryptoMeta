using CryptoMeta.Business.Abstract;
using CryptoMeta.DataAccess.Abstract;
using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMeta.Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void Create(Blog entity)
        {
            _blogDal.Create(entity);
        }

        public void Delete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public Blog GetbyId(int id)
        {
            return _blogDal.GetbyId(id);
        }

        public List<Blog> GetMyArticles(string UserId)
        {
            return _blogDal.GetMyArticles(UserId);
        }

        public List<Blog> SearcMyArticles(string q)
        {
            return _blogDal.SearcMyArticles(q);
        }

        public void Update(Blog entity)
        {
            _blogDal.Update(entity);
        }
    }
}
