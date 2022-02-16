using CryptoMeta.Business.Abstract;
using CryptoMeta.DataAccess.Abstract;
using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMeta.Business.Concrete
{
    public class ForumPostManager : IForumPostService
    {
        private IForumPostDal _forumPostDal;
        public ForumPostManager(IForumPostDal forumPostDal)
        {
            _forumPostDal = forumPostDal;
        }
        public void Create(ForumPost entity)
        {
            _forumPostDal.Create(entity);
        }

        public void Delete(ForumPost entity)
        {
            _forumPostDal.Delete(entity);
        }

        public List<ForumPost> GetAll()
        {
            return _forumPostDal.GetAll();
        }

        public ForumPost GetbyId(int id)
        {
            return _forumPostDal.GetbyId(id);
        }

        public void Update(ForumPost entity)
        {
            _forumPostDal.Update(entity);
        }
    }
}
