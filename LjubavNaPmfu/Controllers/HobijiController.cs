using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using LjubavNaPmfu.Baza;
using LjubavNaPmfu.Services;

namespace LjubavNaPmfu.Controllers
{
    public class HobijiController : Controller
    {
        private readonly ljubavContext _context;
        private readonly KorisnikService _ks;

        public HobijiController(ljubavContext _c,KorisnikService _k)
        {
            _context = _c;
            _ks = _k;
        }

        // GET: HobijiController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hobi.ToListAsync());
        }


        public async Task<IActionResult> Odaberi(int id)
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            Models.KorisnikHobiji h = new Models.KorisnikHobiji(id_k, id);
            if (_ks.PostojiHobi(id_k, id)==false)
            {
                _ks.Dodaj(h);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


     
    }
}
