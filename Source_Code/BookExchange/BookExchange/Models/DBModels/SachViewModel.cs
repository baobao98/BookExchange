using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookExchange.Models.DBModels
{
    public class SachViewModel
    {
        public IEnumerable<Sach> saches { get; set; }
        public string UrlImage = "../images/img-post/";
        public string UrlDetail = "../Post/Detail/";
    }
}
