using CryptoMeta.DataAccess.Abstract;
using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CryptoMeta.DataAccess.Concrete
{
    public class EfCoreForumPostDal : IForumPostRepository
    {
        public void Create(ForumPosts entitiy)
        {
            throw new NotImplementedException();
        }

        public void Delete(ForumPosts entitiy)
        {
            throw new NotImplementedException();
        }

        public List<ForumPosts> GetAll(Expression<Func<ForumPosts, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public ForumPosts GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ForumPosts entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
