using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Models.DBModelsP
{
    public class CatalogItem
    {
        public int matl { get; set; }
        public string tentl { get; set; }
        public int soLuong { get; set; }
        public CatalogItem(int matl,string tentl,int soluong)
        {
            this.matl = matl;
            this.tentl = tentl;
            this.soLuong = soluong;
        }
        public CatalogItem()
        {
            //nothing
        }
    }
}
