using System;
using System.Collections.Generic;

namespace BookExchange.Models
{
    public partial class TrangThai
    {
        public TrangThai()
        {
            Sach = new HashSet<Sach>();
        }

        public int MaTt { get; set; }
        public string TenTt { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}
