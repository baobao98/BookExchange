using System;
using System.Collections.Generic;

namespace BookExchange.Models
{
    public partial class TheLoai
    {
        public TheLoai()
        {
            LoaiMuonNhan = new HashSet<LoaiMuonNhan>();
            Sach = new HashSet<Sach>();
        }

        public int MaTl { get; set; }
        public string TenTl { get; set; }

        public virtual ICollection<LoaiMuonNhan> LoaiMuonNhan { get; set; }
        public virtual ICollection<Sach> Sach { get; set; }
    }
}
