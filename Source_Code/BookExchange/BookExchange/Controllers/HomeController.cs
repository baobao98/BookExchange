using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookExchange.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace BookExchange.Controllers
{
    public class HomeController : Controller
    {
        private BookExchangeDBContext _context;

        public HomeController()
        {
            _context = new BookExchangeDBContext();
        }

        public IActionResult Index()
        {
            DateTime DateNow = DateTime.Now;
            DateTime end = new DateTime(2019, 4, 25);
            var ListSachMoi = _context.Sach.Where(m => (DateNow-m.NgayDang).Days <= 7).Include(m => m.MaKhNavigation).Include(m => m.TacGia).Include(m => m.MaTtNavigation).Include(x => x.AnhSach).ToList();
            var ListAllSach = _context.Sach.Include(m => m.MaKhNavigation).Include(m => m.TacGia).Include(m => m.MaTtNavigation).Include(x => x.AnhSach).ToList();
            var ListKinhTe = _context.Sach.Where(m=>m.MaTlNavigation.TenTl=="Kinh tế").Include(m => m.MaKhNavigation).Include(m => m.TacGia).Include(m => m.MaTtNavigation).Include(x => x.AnhSach).ToList();
            var ListTapChi = _context.Sach.Where(m => m.MaTlNavigation.TenTl == "Tạp chí").Include(m => m.MaKhNavigation).Include(m => m.TacGia).Include(m => m.MaTtNavigation).Include(x => x.AnhSach).ToList();
            var ListTruyenTranh = _context.Sach.Where(m => m.MaTlNavigation.TenTl == "Truyện tranh").Include(m => m.MaKhNavigation).Include(m => m.TacGia).Include(m => m.MaTtNavigation).Include(x => x.AnhSach).ToList();
            var ListThieuNhi = _context.Sach.Where(m => m.MaTlNavigation.TenTl == "Thiếu nhi").Include(m => m.MaKhNavigation).Include(m => m.TacGia).Include(m => m.MaTtNavigation).Include(x => x.AnhSach).ToList();

            SachViewModel viewmodel = new SachViewModel()
            {
                SachKinhTe=ListKinhTe,
                SachMoi=ListSachMoi,
                AllSach = ListAllSach,
                SachTapChi=ListTapChi,
                SachThieuNhi=ListThieuNhi,
                SachTruyenTranh=ListTruyenTranh
                
            };

          
            return View("Index",viewmodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
