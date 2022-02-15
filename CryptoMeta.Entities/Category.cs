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
            Blogs = new HashSet<Blogs>();
            ForumPosts = new HashSet<ForumPosts>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Blogs> Blogs { get; set; }
        public virtual ICollection<ForumPosts> ForumPosts { get; set; }
    }
}
