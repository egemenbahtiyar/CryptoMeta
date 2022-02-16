using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CryptoMeta.Entities
{
    public partial class ForumPost
    {
        public int Id { get; set; }
        public string ForumComment { get; set; }
        public string ForumPostTime { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
