using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Models.DBModels
{
    public class SachViewModel
    {
        public IEnumerable<Sach> SachMoi { get; set; }
        public IEnumerable<Sach> AllSach { get; set; }
        public IEnumerable<Sach> SachKinhTe { get; set; }
        public IEnumerable<Sach> SachTruyenTranh { get; set; }
        public IEnumerable<Sach> SachThieuNhi { get; set;}
        public IEnumerable<Sach> SachTapChi { get; set; }
        public string UrlImage = "../images/img-post/";
    }
}
