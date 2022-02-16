using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CryptoMeta.Entities
{
    public partial class Nft
    {
        public int Id { get; set; }
        public string NftDescription { get; set; }
        public string NftImageUrl { get; set; }
        public DateTime NftCreatedTime { get; set; }
    }
}
