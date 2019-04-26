using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookExchange.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using BookExchange.Models;

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
        public IActionResult CreatePost(PostNewViewModel viewModel)
        {
            int idUser = 1;
            Sach sach = new Sach
            {
                MaSach = idUser.ToString() + DateTime.Now.ToString(),
                TenSach = viewModel.TenSach,
                MaKh = idUser,
                MaTt = viewModel.MaTt,
                MaTl = viewModel.MaTl,
                MoTa = viewModel.MoTa,
                Gia = viewModel.Gia,
                NgayDang = DateTime.Now,
                DaBan = false
            };


            _context.Sach.Add(sach);
            TacGia tacGia = new TacGia
            {
                TenTg = viewModel.TenTacGia,
                MaSach = sach.MaSach
            };

            _context.TacGia.Add(tacGia);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

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

        [Route("post-manager")]
        public IActionResult Manager()
        {
            int idUser = int.Parse(HttpContext.Session.GetString("IdAccount") ?? "0");

            if (idUser == 0)
            {
                return RedirectToAction("Login", "Account");
            }

            List<Sach> lstPost = _context.Sach.Where(n => n.MaKhNavigation.IdaccountNavigation.MaTk == idUser && n.DaBan == false).Include(n => n.MaTlNavigation).Include(n => n.AnhSach).Include(n => n.MaTtNavigation).ToList();

            return View(lstPost);
        }

        public IActionResult Delete(string id)
        {
            Sach sach = _context.Sach.Find(id);

            if (sach != null)
            {
                try
                {
                    sach.DaBan = true;
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                }
            }

            return RedirectToAction("Manager");
        }

        [Route("post-edit")]
        public IActionResult Edit(string id)
        {
            try
            {
                Sach sach = _context.Sach.Where(n => n.MaSach == id).Include(n => n.MaTlNavigation).Include(n => n.MaTtNavigation).FirstOrDefault();

                if (sach != null)
                {
                    List<TheLoai> lstTL = _context.TheLoai.ToList();
                    ViewBag.lstTheLoai = lstTL;

                    return View(sach);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Manager");
            }
        }

        [Route("post-edit")]
        [HttpPost]
        public async Task<IActionResult> EditAsync([Bind("MaSach,TenSach,MaTt,MaTl,Gia,MoTa")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Sach sachDB = _context.Sach.Find(sach.MaSach);
                    sachDB.TenSach = sach.TenSach;
                    sachDB.MaTl = sach.MaTl;
                    sachDB.MaTt = sach.MaTt;
                    sachDB.MoTa = sach.MoTa;
                    if (sach.MaTt != 2)
                    {
                        sachDB.Gia = null;
                    }
                    else
                    {
                        sachDB.Gia = sach.Gia;
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachExists(sach.MaSach))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Manager");
            }

            return View(sach);
        }

        private bool SachExists(string id)
        {
            return _context.Sach.Any(e => e.MaSach == id);
        }
    }
}