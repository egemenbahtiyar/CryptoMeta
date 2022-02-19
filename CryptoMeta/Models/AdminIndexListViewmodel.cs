using CryptoMeta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMeta.Models
{
    public class AdminIndexListViewmodel
    {
        public List<Category> Categories { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<CryptoNew> CryptoNews { get; set; }
        public List<ForumPost> ForumPosts { get; set; }
        public List<Nft> Nfts { get; set; }
        
        

    }
}
