using System;
using System.Collections.Generic;

namespace BookExchange.Models.DBModels
{
    public partial class TacGia
    {
        public int MaTg { get; set; }
        public string TenTg { get; set; }
        public string MaSach { get; set; }

        public virtual Sach MaSachNavigation { get; set; }
    }
}
