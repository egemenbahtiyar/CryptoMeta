using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMeta.Models
{
    public class CryptoNewModel
    {
        public int Id { get; set; }
        public string NewDescription { get; set; }
        public DateTime NewCreatedTime { get; set; }
        public string NewTitle { get; set; }
    }
}
