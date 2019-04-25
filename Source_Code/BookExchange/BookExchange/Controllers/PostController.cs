using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookExchange.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace BookExchange.Controllers
{
    public class PostController : Controller
    {
        private BookExchangeDBContext _context;// = new BookExchangeDBContext();
        
        public PostController()
        {
            _context =new BookExchangeDBContext();
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(string id = "nam-centimet-tren-giay")
        {
            //id = "a";
            var sachDetial = _context.Sach.Where(s => s.MaSach == id).Include(x => x.MaKhNavigation).Include(x => x.AnhSach).Include(x => x.MaKhNavigation).Include(x => x.MaTtNavigation).Include(x=>x.TacGia).Include(x=>x.MaTlNavigation).SingleOrDefault();
            //List<string> anh=_context.AnhSach.Where(a=>a.MaSach==id)
            return View("Detail", sachDetial);
        }
        public IActionResult SearchCatalog(int idTL)
        {
            //var Theloai = _context.TheLoai.Where(t => t.MaTl == idTL).SingleOrDefault();
            List<Sach> ds = new List<Sach>();
            ds = _context.Sach.Where(s => s.MaTl == idTL).ToList();
            return View("CatalogDetail",ds);
        }
    }
}