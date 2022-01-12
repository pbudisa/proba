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

        public HobijiController(ljubavContext _c, KorisnikService _k)
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
            if (_ks.PostojiHobi(id_k, id) == false)
            {
                _ks.Dodaj(h);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Lista()
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            var sve = _context.Korisnik.Where(x => x.Id != id_k);
            var id = _context.Match.Where(x => x.IdPrvi.Equals(id_k));
            var popis=sve.ToList();
            foreach(var jedan in id)
            {
                for(int i = 0; i < popis.Count(); i++)
                {
                    if (jedan.IdDrugi.Equals(popis[i].Id))
                    {
                        popis.Remove(popis[i]);
                    }
                }
            }
            
            return View(popis.ToList());
        }
        public async Task<IActionResult> Match(int id)
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            Models.Match m = new Models.Match(id_k, id);
            if (_ks.Matchan(m.id1,m.id2) == false)
            {
                _ks.Matchaj(m);
                await _context.SaveChangesAsync();
            }
            return RedirectToRoute(new { controller = "Hobiji", action = "Lista" });
        }

        public async Task<IActionResult> MatchLista()
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            var sve = _context.Match.Include(k=>k.IdPrviNavigation).Where(x => x.IdDrugi.Equals(id_k));
            return View(await sve.ToListAsync());
        }
        public async Task<IActionResult> Profil()
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            var profil = _context.KorisnikHobiji.Include(h=>h.IdhNavigation).Include(k=>k.IdkNavigation).Where(x => x.IdkNavigation.Id.Equals(id_k));
            return View(await profil.ToListAsync());
        }

    }
}
