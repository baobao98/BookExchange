using System;
using System.Collections.Generic;

namespace BookExchange.Models.DBModels
{
    public partial class Sach
    {
        public Sach()
        {
            AnhSach = new HashSet<AnhSach>();
            LoaiMuonNhan = new HashSet<LoaiMuonNhan>();
            TacGia = new HashSet<TacGia>();
        }

        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public bool DaBan { get; set; }
        public int MaKh { get; set; }
        public int MaTt { get; set; }
        public int MaTl { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayDang { get; set; }
        public decimal? Gia { get; set; }

        public virtual User MaKhNavigation { get; set; }
        public virtual TheLoai MaTlNavigation { get; set; }
        public virtual TrangThai MaTtNavigation { get; set; }
        public virtual ICollection<AnhSach> AnhSach { get; set; }
        public virtual ICollection<LoaiMuonNhan> LoaiMuonNhan { get; set; }
        public virtual ICollection<TacGia> TacGia { get; set; }
    }
}
