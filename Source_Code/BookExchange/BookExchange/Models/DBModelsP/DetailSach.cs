using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Models.DBModelsP
{
    public class DetailSach
    {
        public string tenSach { get; set; }
        public string tacGia { get; set; }
        public string nguoiDang { get; set; }
        public DateTime ngayDang { get; set; }
        public int sdt { get; set; }
        public string email { get; set; }
        public string gioiTinh { get; set; }
        public string tinhTrang { get; set; }
        public string hinhThuc { get; set; }
        public string theLoai { get; set; }
        public string chiTiet { get; set; }
        public List<string> anh { get; set; }
        public DetailSach(string tenSach, string tacGia, string nguoiDang, DateTime ngayDang, int sdt, string email, string gioiTinh,
            string tinhTrang, string hinhThuc, string theLoai, string chiTiet, List<string> anh)
        {
            this.tenSach = tenSach;
            this.tacGia = tacGia;
            this.nguoiDang = nguoiDang;
            this.ngayDang = ngayDang;
            this.sdt = sdt;
            this.email = email;
            this.gioiTinh = gioiTinh;
            this.tinhTrang = tinhTrang;
            this.hinhThuc = hinhThuc;
            this.theLoai = theLoai;
            this.chiTiet = chiTiet;
            this.anh = anh;
        }
    }
}
