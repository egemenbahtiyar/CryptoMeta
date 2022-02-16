using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CryptoMeta.Entities
{
    public partial class CryptoNew
    {
        public int Id { get; set; }
        public string NewDescription { get; set; }
        public DateTime NewCreatedTime { get; set; }
        public string NewTitle { get; set; }
    }
}
