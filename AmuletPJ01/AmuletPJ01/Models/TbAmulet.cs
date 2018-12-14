using System;
using System.Collections.Generic;

namespace AmuletPJ01.Models
{
    public partial class TbAmulet
    {
        public int AmuletId { get; set; }
        public int? ManualId { get; set; }
        public string Generation { get; set; }
        public string Year { get; set; }
        public string Place { get; set; }
        public string Price { get; set; }
        public byte[] Picture { get; set; }

        public TbManual Manual { get; set; }
    }
}
