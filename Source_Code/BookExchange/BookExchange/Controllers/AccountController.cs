using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookExchange.Models.DBModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RES.Models.Securities;

namespace BookExchange.Controllers
{
    public class AccountController : Controller
    {
        BookExchangeDBContext db = new BookExchangeDBContext();

        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(Account account, bool rememberme)
        {
            string mk1 = HashPwdTool.GeneratePassword("1");
            account = db.Account.Where(n => n.TaiKhoan == account.TaiKhoan && HashPwdTool.CheckPassword(account.MatKhau, n.MatKhau)).SingleOrDefault();

            if (account == null)
            {
                ModelState.AddModelError(string.Empty, "Tài khoản hoặc mật khẩu không đúng");
                ViewBag.Error = "Username or Password was incorrect";
                return View();
            }

            await AuthenticateUser(account, rememberme);

            return RedirectToAction("Index", "Home");
        }

        private async Task AuthenticateUser(Account acc, bool isPersistent)
        {
            // Initialization.
            var claims = new List<Claim>();

            try
            {
                // Setting
                HttpContext.Session.SetString("IdAccount", acc.MaTk.ToString());
                HttpContext.Session.SetString("UserName", acc.TaiKhoan);
                claims.Add(new Claim(ClaimTypes.Name, acc.TaiKhoan));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                // Sign In.
                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent });
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }
        }

        public async Task<IActionResult> Signout()
        {
            try
            {
                // Setting.
                var authenticationManager = Request.HttpContext;

                // Sign Out.
                HttpContext.Session.Remove("UserName");
                HttpContext.Session.Remove("IdAccount");
                await authenticationManager.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }

            // Info.
            return this.RedirectToAction("Index", "Home");
        }
    }
}