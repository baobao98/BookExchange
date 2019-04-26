using System;
using System.Collections.Generic;

namespace BookExchange.Models.DBModels
{
    public partial class AnhSach
    {
        public int Idanh { get; set; }
        public string MaSach { get; set; }
        public string ImgUrl { get; set; }

        public virtual Sach MaSachNavigation { get; set; }
    }
}
