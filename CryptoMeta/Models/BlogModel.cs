using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMeta.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string BlogDescription { get; set; }
        public string Title { get; set; }
        public string BlogImageUrl { get; set; }
        public int? LikeCount { get; set; }
        public int? DislikeCount { get; set; }
        public string BlogComment { get; set; }
        public string CategoryName { get; set; }
        public DateTime BlogCreatedTime { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
