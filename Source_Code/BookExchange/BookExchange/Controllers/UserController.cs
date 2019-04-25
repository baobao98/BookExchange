using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookExchange.Models.DBModels;

namespace BookExchange.Controllers
{
    public class UserController : Controller
    {
        private readonly BookExchangeDBContext _context = new BookExchangeDBContext();
        
        // GET: User
        public async Task<IActionResult> Index()
        {
            var bookExchangeDBContext = _context.User.Include(u => u.IdaccountNavigation);
            return View(await bookExchangeDBContext.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.IdaccountNavigation)
                .FirstOrDefaultAsync(m => m.MaKh == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            ViewData["Idaccount"] = new SelectList(_context.Account, "MaTk", "MatKhau");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKh,HoTen,NgaySinh,GioiTinh,DienThoai,Email,Idaccount,DiaChi")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idaccount"] = new SelectList(_context.Account, "MaTk", "MatKhau", user.Idaccount);
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["Idaccount"] = new SelectList(_context.Account, "MaTk", "MatKhau", user.Idaccount);
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaKh,HoTen,NgaySinh,GioiTinh,DienThoai,Email,Idaccount,DiaChi")] User user)
        {
            if (id != user.MaKh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.MaKh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idaccount"] = new SelectList(_context.Account, "MaTk", "MatKhau", user.Idaccount);
            return View(user);
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.MaKh == id);
        }
    }
}
