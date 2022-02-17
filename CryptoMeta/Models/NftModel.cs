using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMeta.Models
{
    public class NftModel
    {
        public int Id { get; set; }
        public string NftDescription { get; set; }
        public string NftImageUrl { get; set; }
        public DateTime NftCreatedTime { get; set; }
    }
}
