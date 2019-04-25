using System;
using System.Collections.Generic;

namespace BookExchange.Models
{
    public partial class LoaiMuonNhan
    {
        public string IdloaiMuonNhan { get; set; }
        public int MaTl { get; set; }
        public int MaSach { get; set; }

        public virtual TheLoai MaTlNavigation { get; set; }
    }
}
