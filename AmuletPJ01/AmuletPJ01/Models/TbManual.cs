using System;
using System.Collections.Generic;

namespace AmuletPJ01.Models
{
    public partial class TbManual
    {
        public TbManual()
        {
            TbAmulet = new HashSet<TbAmulet>();
        }

        public int ManualId { get; set; }
        public byte[] Picture2 { get; set; }

        public ICollection<TbAmulet> TbAmulet { get; set; }
    }
}
