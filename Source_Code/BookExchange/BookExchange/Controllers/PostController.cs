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
            _context = new BookExchangeDBContext();
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreatePost()
        {
            ViewBag.TheLoai = _context.TheLoai.ToList();
            ViewBag.TrangThai = _context.TrangThai.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(Sach sach)
        {
            return View();
        }


        [HttpGet("{id}")]
        public IActionResult Detail(string id = "nam-centimet-tren-giay")
        {
            //id = "a";
            var sachDetial = _context.Sach.Where(s => s.MaSach == id).Include(x => x.MaKhNavigation).Include(x => x.AnhSach).Include(x => x.MaKhNavigation).Include(x => x.MaTtNavigation).Include(x => x.TacGia).Include(x => x.MaTlNavigation).SingleOrDefault();
            //List<string> anh=_context.AnhSach.Where(a=>a.MaSach==id)
            return View("Detail", sachDetial);
        }

        [Route("search")]
        [HttpGet("{idTL}/{keyword}")]
        public IActionResult Search(int idTL = 0, string keyword = "")
        {
            if (idTL != 0)
            {
                List<Sach> ds = null;
                ds = _context.Sach.Where(s => s.MaTl == idTL).OrderByDescending(n => n.NgayDang).Include(n => n.AnhSach).Include(n => n.MaTtNavigation).Include(n => n.TacGia).ToList();
                return View("Search", ds.Take(12).ToList());
            }
            else
            {
                List<Sach> lstSach = new List<Sach>();
                lstSach.AddRange(_context.Sach.Where(s => s.TenSach.Contains(keyword)).OrderByDescending(n => n.NgayDang).Include(n => n.AnhSach).Include(n => n.MaTtNavigation).Include(n => n.TacGia).ToList());

                //List<TacGia> lstTacGia = _context.TacGia.Where(n => n.TenTg.Contains(keyWord)).Include(n => n.MaSachNavigation).ToList();

                //foreach (var item in lstTacGia)
                //{
                //    lstSach.Add(item.MaSachNavigation);
                //}

                return View("Search", lstSach.Take(12).ToList());
            }
        }
    }
}