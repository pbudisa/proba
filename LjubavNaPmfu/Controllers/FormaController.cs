using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using LjubavNaPmfu.Services;
using LjubavNaPmfu.Baza;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LjubavNaPmfu.Controllers
{
    public class FormaController : Controller
    {
        private KorisnikService _formaservice;
        private ljubavContext _context;
        public FormaController(KorisnikService ks,ljubavContext c)
        {
            _formaservice = ks;
            _context = c;
        }

        // GET: FormaController
        public ActionResult Index()
        {
            return View();
        }
        


        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("Role") == "korisnik")
                return RedirectToRoute(new { controller = "Hobiji", action = "Lista" });
            ViewData["Ids"] = new SelectList(_context.StudijskeGrupe, "IdG", "Naziv");
            return View();
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Role") == "korisnik")
                return RedirectToRoute(new { controller = "Hobiji", action = "Lista" });
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }


        // POST: FormaController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string username, string password, string password2,string ime,string dob,string omeni, string mob,int studij,string spol,string zanimaju)
        {
            if (HttpContext.Session.GetString("Role") == "korisnik")
                return RedirectToRoute(new { controller = "Hobiji", action = "Lista" });
            ViewData["Ids"] = new SelectList(_context.StudijskeGrupe, "IdG", "Naziv", studij);
            var korisnik = _formaservice.VerifyKorisnik(username, password, password2,ime,dob,omeni,mob,studij,spol,zanimaju);
            if (korisnik != null)
            {
                _formaservice.Novi(korisnik);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                ViewBag.Poruka = "Morate unijeti sve podatke i lozinka mora imati najmanje 5 znakova";
                return View();
            }
        }
        // POST: FormaController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            if (HttpContext.Session.GetString("Role") == "korisnik" || HttpContext.Session.GetString("Role") == "admin")
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            var korisnik = _formaservice.LoginKorisnik(username, password);
            if (korisnik != null)
            {
                HttpContext.Session.SetString("Id", korisnik.id.ToString());
                HttpContext.Session.SetString("Username", korisnik.username);
                HttpContext.Session.SetString("Role", korisnik.role);
                
                if (_formaservice.Hobijii(korisnik.id) == true)
                {
                    return RedirectToRoute(new { controller = "Hobiji", action = "Lista" });
                }
                else
                {
                    return RedirectToRoute(new { controller = "Hobiji", action = "Index" });
                }
            }
            else
            {
                ViewBag.Message = "Pogresan unos!";
                return View();
            }
        }
    }
}
