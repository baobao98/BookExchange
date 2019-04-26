using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookExchange.Models.DBModels
{
    public partial class User
    {
        public User()
        {
            Sach = new HashSet<Sach>();
        }

        public int MaKh { get; set; }
        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        public DateTime? NgaySinh { get; set; }
        [Required(ErrorMessage = "Giới tính không được để trống")]
        public string GioiTinh { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string DienThoai { get; set; }
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }
        public int Idaccount { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string DiaChi { get; set; }

        public virtual Account IdaccountNavigation { get; set; }
        public virtual ICollection<Sach> Sach { get; set; }
    }
}
