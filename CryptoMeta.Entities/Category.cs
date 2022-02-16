using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CryptoMeta.Entities
{
    public partial class Category
    {
        public Category()
        {
            Blogs = new HashSet<Blog>();
            ForumPosts = new HashSet<ForumPost>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<ForumPost> ForumPosts { get; set; }
    }
}
