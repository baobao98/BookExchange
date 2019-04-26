using BookExchange.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Models
{
    public class PostNewViewModel
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int MaTt { get; set; }
        public int MaTl { get; set; }
        public string MoTa { get; set; }
        public decimal? Gia { get; set; }
        public string TenTacGia { get; set; }

        public virtual ICollection<AnhSach> AnhSach { get; set; }
        public virtual ICollection<LoaiMuonNhan> LoaiMuonNhan { get; set; }
        public virtual ICollection<TacGia> TacGia { get; set; }
    }
}
