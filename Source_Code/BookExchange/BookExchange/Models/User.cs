using System;
using System.Collections.Generic;

namespace BookExchange.Models
{
    public partial class User
    {
        public User()
        {
            Sach = new HashSet<Sach>();
        }

        public int MaKh { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public int Idaccount { get; set; }
        public string DiaChi { get; set; }

        public virtual Account IdaccountNavigation { get; set; }
        public virtual ICollection<Sach> Sach { get; set; }
    }
}
