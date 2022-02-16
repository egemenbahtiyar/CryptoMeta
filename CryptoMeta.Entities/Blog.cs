using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CryptoMeta.Entities
{
    public partial class Blog
    {
        public int Id { get; set; }
        public string BlogDescription { get; set; }
        public string Title { get; set; }
        public string BlogImageUrl { get; set; }
        public int? LikeCount { get; set; }
        public int? DislikeCount { get; set; }
        public string BlogComment { get; set; }
        public DateTime BlogCreatedTime { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
