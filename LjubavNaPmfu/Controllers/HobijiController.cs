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
using System.IO;

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
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            var sve = _context.Hobi;
            var posebni = _context.KorisnikHobiji.Where(x => x.Idk.Equals(id_k));
            var popis = sve.ToList();
            foreach(var p in posebni)
            {
                for (int i=0;i < popis.Count; i++)
                {
                    if(p.Idh == popis[i].IdH)
                    {
                        popis.Remove(popis[i]);
                    }
                }
            }
            return View(popis.ToList());
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
            var ja = _context.Korisnik.Where(x => x.Id.Equals(id_k)).FirstOrDefault();
            var sve = _context.Korisnik.Include(s=>s.IdsNavigation).Where(x => x.Id != id_k);
            var id = _context.Match.Where(x => x.IdPrvi.Equals(id_k));
            var odbijeni = _context.Odbijeni.Where(x => x.IdPrvi.Equals(id_k));
            var blokani = _context.Blokirani.Where(x => x.IdPrvi.Equals(id_k));
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
            foreach(var o in odbijeni)
            {
                for(int i = 0; i < popis.Count(); i++)
                {
                    if(o.IdPrvi.Equals(popis[i].Id) || o.IdDrugi.Equals(popis[i].Id))
                    {
                        popis.Remove(popis[i]);
                    }
                }
            }
            foreach(var b in blokani)
            {
                for (int i = 0; i < popis.Count(); i++)
                {
                    if (b.IdPrvi.Equals(popis[i].Id) || b.IdDrugi.Equals(popis[i].Id))
                    {
                        popis.Remove(popis[i]);
                    }
                }
            }
            if (ja.Spol == "z")
            {
                ViewBag.slika = "../female.png";
                if (ja.Zanimaju == "z")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("m") || (x.Spol.Equals("z") && x.Zanimaju.Equals("m")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else if (ja.Zanimaju == "m")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("z") || (x.Spol.Equals("m") && x.Zanimaju.Equals("m")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else
                {
                    ViewBag.Zanimaju = "oboje";
                    var spol = _context.Korisnik.Where(x => x.Zanimaju.Equals("m"));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
            }
            else if (ja.Spol == "m")
            {
                if (ja.Zanimaju == "z")
                {
                    var spol  = _context.Korisnik.Where(x => x.Spol.Equals("m") || (x.Spol.Equals("z") && x.Zanimaju.Equals("z")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else if (ja.Zanimaju == "m")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("z") || (x.Spol.Equals("m") && x.Zanimaju.Equals("z")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else
                {
                    ViewBag.Zanimaju = "oboje";
                    var spol  = _context.Korisnik.Where(x => x.Zanimaju.Equals("z"));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
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

        public async Task<IActionResult> Odbij(int id)
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            Models.Odbijeni o = new Models.Odbijeni(id_k, id);
            if(_ks.Odbijen(id_k,id) == false)
            {
                _ks.Odbij(o);
                await _context.SaveChangesAsync();
            }
            return RedirectToRoute(new { controller = "Hobiji", action = "Lista" });
        }

        public async Task<IActionResult> Blokiraj(int id)
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            Models.Blokirani b = new Models.Blokirani(id_k, id);
            if (_ks.Blokan(id_k, id) == false)
            {
                _ks.Blokaj(b);
                var brisi = await _context.Match.FirstOrDefaultAsync(x=> x.IdDrugi.Equals(id));
                _context.Match.Remove(brisi);
                await _context.SaveChangesAsync();
            }
            return RedirectToRoute(new { controller = "Hobiji", action = "MatchLista" });
        }

        public async Task<IActionResult> MatchLista()
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            var posebni = _context.Match.Include(k=>k.IdPrviNavigation).Where(x=> x.IdPrvi.Equals(id_k));
            var sve = _context.Match.Include(k => k.IdPrviNavigation).Where(x => x.IdDrugi.Equals(id_k));
            var blokani = _context.Blokirani.Where(x => x.IdPrvi.Equals(id_k));
            var popis = sve.ToList();
            List<Match> lista = new List<Match>();

            if(posebni.Count()>0 && popis.Count >0)
            {
                foreach(var p in posebni)
                {
                    for(int i = 0; i < popis.Count(); i++)
                    {
                        if(p.IdDrugi == popis[i].IdPrvi)
                        {
                            lista.Add(popis[i]);
                        }
                    }
                }
            }
            
            
            return View(lista.ToList());
        }

        public  ActionResult Chat()
        {
            return View("Chat");
        }
        public async Task<IActionResult> Profil(int id)
        {
            if(id == 0)
            {
                return View("Error2");
            }
            var dbkorisnik = _context.Korisnik.Include(s=>s.IdsNavigation).Where(x=>x.Id.Equals(id));
            foreach(var k in dbkorisnik)
            {
                ViewBag.Ime = k.Ime;
                ViewBag.Dob = k.Dob;
                ViewBag.Omeni = k.Omeni;
                ViewBag.Studij = k.IdsNavigation.Naziv;
                ViewBag.Spol = k.Spol;
                ViewBag.Zanimaju = k.Zanimaju;

            }
            var profil = _context.KorisnikHobiji.Include(h=>h.IdhNavigation).Include(k=>k.IdkNavigation).Where(x => x.IdkNavigation.Id.Equals(id));
            return View(await profil.ToListAsync());
        }

        public async Task<IActionResult> Filter(string kategorija)
        {
            ViewBag.Kategorija = kategorija;
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            var ja = _context.Korisnik.Where(x => x.Id.Equals(id_k)).FirstOrDefault();
            var sve = _context.KorisnikHobiji.Include(k=>k.IdkNavigation).Include(h=>h.IdhNavigation).Where(x => x.IdhNavigation.Naziv.Equals(kategorija) && x.Idk!=id_k);
            var popis = sve.ToList();
            var id = _context.Match.Where(x => x.IdPrvi.Equals(id_k));
            var odbijeni = _context.Odbijeni.Where(x => x.IdPrvi.Equals(id_k));
            var blokani = _context.Blokirani.Where(x => x.IdPrvi.Equals(id_k));
            foreach (var jedan in id)
            {
                for (int i = 0; i < popis.Count(); i++)
                {
                    if (jedan.IdDrugi.Equals(popis[i].Idk))
                    {
                        popis.Remove(popis[i]);
                    }
                }
            }
            foreach (var o in odbijeni)
            {
                for (int i = 0; i < popis.Count(); i++)
                {
                    if (o.IdPrvi.Equals(popis[i].Idk) || o.IdDrugi.Equals(popis[i].Idk))
                    {
                        popis.Remove(popis[i]);
                    }
                }
            }
            foreach (var b in blokani)
            {
                for (int i = 0; i < popis.Count(); i++)
                {
                    if (b.IdPrvi.Equals(popis[i].Idk) || b.IdDrugi.Equals(popis[i].Idk))
                    {
                        popis.Remove(popis[i]);
                    }
                }
            }
            if (ja.Spol == "z")
            {
                if (ja.Zanimaju == "z")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("m") || (x.Spol.Equals("z") && x.Zanimaju.Equals("m")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].IdkNavigation.Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else if (ja.Zanimaju == "m")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("z") || (x.Spol.Equals("m") && x.Zanimaju.Equals("m")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].IdkNavigation.Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else
                {
                    var spol = _context.Korisnik.Where(x => x.Zanimaju.Equals("m"));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].IdkNavigation.Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
            }
            else if (ja.Spol == "m")
            {
                if (ja.Zanimaju == "z")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("m") || (x.Spol.Equals("z") && x.Zanimaju.Equals("z")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].IdkNavigation.Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else if (ja.Zanimaju == "m")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("z") || (x.Spol.Equals("m") && x.Zanimaju.Equals("z")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].IdkNavigation.Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else
                {
                    var spol = _context.Korisnik.Where(x => x.Zanimaju.Equals("z"));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].IdkNavigation.Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
            }
            return View(popis.ToList());
        }
        public async Task<IActionResult> Grupa(string studij)
        {
            ViewBag.Grupa = studij;
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            var ja = _context.Korisnik.Where(x => x.Id.Equals(id_k)).FirstOrDefault();
            var sve = _context.Korisnik.Where(x =>x.IdsNavigation.Naziv==studij && x.Id != id_k);
            var popis = sve.ToList();
            var id = _context.Match.Where(x => x.IdPrvi.Equals(id_k));
            var odbijeni = _context.Odbijeni.Where(x => x.IdPrvi.Equals(id_k));
            var blokani = _context.Blokirani.Where(x => x.IdPrvi.Equals(id_k));
            foreach (var jedan in id)
            {
                for (int i = 0; i < popis.Count(); i++)
                {
                    if (jedan.IdDrugi.Equals(popis[i].Id))
                    {
                        popis.Remove(popis[i]);
                    }
                }
            }
            foreach (var o in odbijeni)
            {
                for (int i = 0; i < popis.Count(); i++)
                {
                    if (o.IdPrvi.Equals(popis[i].Id) || o.IdDrugi.Equals(popis[i].Id))
                    {
                        popis.Remove(popis[i]);
                    }
                }
            }
            foreach (var b in blokani)
            {
                for (int i = 0; i < popis.Count(); i++)
                {
                    if (b.IdPrvi.Equals(popis[i].Id) || b.IdDrugi.Equals(popis[i].Id))
                    {
                        popis.Remove(popis[i]);
                    }
                }
            }
            if (ja.Spol == "z")
            {
                if (ja.Zanimaju == "z")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("m") || (x.Spol.Equals("z") && x.Zanimaju.Equals("m")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else if (ja.Zanimaju == "m")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("z") || (x.Spol.Equals("m") && x.Zanimaju.Equals("m")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else
                {
                    var spol = _context.Korisnik.Where(x => x.Zanimaju.Equals("m"));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
            }
            else if (ja.Spol == "m")
            {
                if (ja.Zanimaju == "z")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("m") || (x.Spol.Equals("z") && x.Zanimaju.Equals("z")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else if (ja.Zanimaju == "m")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("z") || (x.Spol.Equals("m") && x.Zanimaju.Equals("z")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else
                {
                    var spol = _context.Korisnik.Where(x => x.Zanimaju.Equals("z"));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
            }
            return View(popis.ToList());
        }

        public async Task<IActionResult> Match2(int id)
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            Models.Match m = new Models.Match(id_k, id);
            if (_ks.Matchan(m.id1, m.id2) == false)
            {
                _ks.Matchaj(m);
                await _context.SaveChangesAsync();
            }
            return RedirectToRoute(new { controller = "Hobiji", action = "Lista" });
        }

        public async Task<IActionResult> Odbij2(int id)
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            Models.Odbijeni o = new Models.Odbijeni(id_k, id);
            if (_ks.Odbijen(id_k, id) == false)
            {
                _ks.Odbij(o);
                await _context.SaveChangesAsync();
            }
            return RedirectToRoute(new { controller = "Hobiji", action = "Lista" });
        }

        public async Task<IActionResult> Match3(int id)
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            Models.Match m = new Models.Match(id_k, id);
            if (_ks.Matchan(m.id1, m.id2) == false)
            {
                _ks.Matchaj(m);
                await _context.SaveChangesAsync();
            }
            return RedirectToRoute(new { controller = "Hobiji", action = "Lista" });
        }
        public async Task<IActionResult> Odbij3(int id)
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            Models.Odbijeni o = new Models.Odbijeni(id_k, id);
            if (_ks.Odbijen(id_k, id) == false)
            {
                _ks.Odbij(o);
                await _context.SaveChangesAsync();
            }
            return RedirectToRoute(new { controller = "Hobiji", action = "Lista" });
        }
        public async Task<IActionResult> Match4(int id)
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            Models.Match m = new Models.Match(id_k, id);
            if (_ks.Matchan(m.id1, m.id2) == false)
            {
                _ks.Matchaj(m);
                await _context.SaveChangesAsync();
            }
            return RedirectToRoute(new { controller = "Hobiji", action = "Lista" });
        }
        public async Task<IActionResult> Odbij4(int id)
        {
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            Models.Odbijeni o = new Models.Odbijeni(id_k, id);
            if (_ks.Odbijen(id_k, id) == false)
            {
                _ks.Odbij(o);
                await _context.SaveChangesAsync();
            }
            return RedirectToRoute(new { controller = "Hobiji", action = "Lista" });
        }
        
        public async Task<IActionResult> Spol(string spoll)
        {
            if(spoll == "m")
            {
                ViewBag.Spol = "Muški";
            }
            else
            {
                ViewBag.Spol = "Ženske";
            }
            int id_k = int.Parse(HttpContext.Session.GetString("Id"));
            var ja = _context.Korisnik.Where(x => x.Id.Equals(id_k)).FirstOrDefault();
            var sve = _context.Korisnik.Where(x => x.Spol==spoll && x.Id != id_k);
            var popis = sve.ToList();
            var id = _context.Match.Where(x => x.IdPrvi.Equals(id_k));
            var odbijeni = _context.Odbijeni.Where(x => x.IdPrvi.Equals(id_k));
            var blokani = _context.Blokirani.Where(x => x.IdPrvi.Equals(id_k));
            foreach (var jedan in id)
            {
                for (int i = 0; i < popis.Count(); i++)
                {
                    if (jedan.IdDrugi.Equals(popis[i].Id))
                    {
                        popis.Remove(popis[i]);
                    }
                }
            }
            foreach (var o in odbijeni)
            {
                for (int i = 0; i < popis.Count(); i++)
                {
                    if (o.IdPrvi.Equals(popis[i].Id) || o.IdDrugi.Equals(popis[i].Id))
                    {
                        popis.Remove(popis[i]);
                    }
                }
            }
            foreach (var b in blokani)
            {
                for (int i = 0; i < popis.Count(); i++)
                {
                    if (b.IdPrvi.Equals(popis[i].Id) || b.IdDrugi.Equals(popis[i].Id))
                    {
                        popis.Remove(popis[i]);
                    }
                }
            }
            if (ja.Spol == "z")
            {
                if (ja.Zanimaju == "z")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("m") || (x.Spol.Equals("z") && x.Zanimaju.Equals("m")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else if (ja.Zanimaju == "m")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("z") || (x.Spol.Equals("m") && x.Zanimaju.Equals("m")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else
                {
                    var spol = _context.Korisnik.Where(x => x.Zanimaju.Equals("m"));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
            }
            else if (ja.Spol == "m")
            {
                if (ja.Zanimaju == "z")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("m") || (x.Spol.Equals("z") && x.Zanimaju.Equals("z")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else if (ja.Zanimaju == "m")
                {
                    var spol = _context.Korisnik.Where(x => x.Spol.Equals("z") || (x.Spol.Equals("m") && x.Zanimaju.Equals("z")));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
                else
                {
                    var spol = _context.Korisnik.Where(x => x.Zanimaju.Equals("z"));
                    foreach (var s in spol)
                    {
                        for (int i = 0; i < popis.Count; i++)
                        {
                            if (popis[i].Id.Equals(s.Id))
                            {
                                popis.Remove(popis[i]);
                            }
                        }
                    }
                }
            }
            return View(popis.ToList());
        }
        
    }
}
