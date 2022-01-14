using LjubavNaPmfu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http;
using LjubavNaPmfu.Baza;
using LjubavNaPmfu.Services;

namespace LjubavNaPmfu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ljubavContext _context;
        private readonly KorisnikService _ks;

        public HomeController(ILogger<HomeController> logger,ljubavContext c,KorisnikService s)
        {
            _logger = logger;
            _context = c;
            _ks = s;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Prvi()
        {
            return View("Prvi");
        }

        public IActionResult Error2()
        {
            ViewBag.poruka = "Error 404";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string username, string password)
        {
            if (HttpContext.Session.GetString("Role") == "korisnik" || HttpContext.Session.GetString("Role") == "admin")
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            var korisnik = _ks.LoginKorisnik(username, password);
            if (korisnik != null)
            {
                HttpContext.Session.SetString("Id", korisnik.id.ToString());
                HttpContext.Session.SetString("Username", korisnik.username);
                HttpContext.Session.SetString("Role", korisnik.role);
                HttpContext.Session.SetString("Ime", korisnik.ime);
                HttpContext.Session.SetString("Dob", korisnik.dob.ToString());
                HttpContext.Session.SetString("Omeni", korisnik.omeni);
                if (_ks.Hobijii(korisnik.id) == true)
                {
                    return RedirectToRoute(new { controller = "Hobiji", action = "Lista" });
                }
                else
                {
                    return RedirectToRoute(new { controller = "Home", action = "Prvi" });
                }
            }
            else
            {
                ViewBag.Messag2 = "Pogresan unos!";
                return View("Index");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
