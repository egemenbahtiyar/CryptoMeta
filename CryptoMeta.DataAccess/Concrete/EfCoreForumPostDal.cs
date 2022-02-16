using CryptoMeta.DataAccess.Abstract;
using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoMeta.DataAccess.Concrete
{
    public class EfCoreForumPostDal: EfCoreGenericRepository<ForumPost,CryptoMetaContext>, IForumPostDal
    {
    }
}
