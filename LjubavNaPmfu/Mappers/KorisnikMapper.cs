using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LjubavNaPmfu.Models;

namespace LjubavNaPmfu.Mappers
{
    public class KorisnikMapper
    {
        public static Korisnik FromDatabase(Baza.Korisnik k)
        {
            return new Korisnik(k.IdK, k.Username, k.Lozinka,k.Role);
        }
        public static Baza.Korisnik ToDatabase(Korisnik k)
        {
            Baza.Korisnik x = new Baza.Korisnik
            {
                Username=k.username,
                Lozinka=k.lozinka,
                Role = k.role

            };

            if (k.id != null)
            {
                x.IdK = (int)k.id;
            }

            return x;

        }
    }
}
