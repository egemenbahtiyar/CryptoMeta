using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMeta.Business.Abstract
{
    public interface IForumPostService
    {
        ForumPost GetbyId(int id);
        List<ForumPost> GetAll();
        void Create(ForumPost entity);
        void Delete(ForumPost entity);
        void Update(ForumPost entity);
    }
}
