using System;
using System.Collections.Generic;

namespace BookExchange.Models.DBModels
{
    public partial class LoaiMuonNhan
    {
        public int IdloaiMuonNhan { get; set; }
        public int MaTl { get; set; }
        public string MaSach { get; set; }

        public virtual Sach MaSachNavigation { get; set; }
        public virtual TheLoai MaTlNavigation { get; set; }
    }
}
