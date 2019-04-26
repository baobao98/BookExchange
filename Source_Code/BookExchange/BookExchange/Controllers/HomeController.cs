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
            var ListSach = _context.Sach.Include(m => m.MaKhNavigation).Include(m => m.TacGia).Include(m => m.MaTtNavigation).Include(x => x.AnhSach).ToList().Take(5);

            SachViewModel viewmodel = new SachViewModel()
            {
                saches = ListSach
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
