using System;
using System.Collections.Generic;

namespace BookExchange.Models
{
    public partial class Sach
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public bool DaBan { get; set; }
        public int MaKh { get; set; }
        public int MaTt { get; set; }
        public int MaTl { get; set; }
        public DateTime NgayDang { get; set; }

        public virtual User MaKhNavigation { get; set; }
        public virtual TheLoai MaTlNavigation { get; set; }
        public virtual TrangThai MaTtNavigation { get; set; }
    }
}
