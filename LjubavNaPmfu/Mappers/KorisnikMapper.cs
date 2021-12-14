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
            return new Korisnik(k.Id, k.Username, k.Lozinka, k.Role,k.Ime,k.Dob,k.Omeni,k.Mobitel);
        }
        public static Baza.Korisnik ToDatabase(Korisnik k)
        {
            Baza.Korisnik x = new Baza.Korisnik
            {
                Username = k.username,
                Lozinka = k.lozinka,
                Role = k.role,
                Ime=k.ime,
                Dob=k.dob,
                Omeni=k.omeni,
                Mobitel=k.mob
            };

            if (k.id != null)
            {
                x.Id = (int)k.id;
            }

            return x;

        }
    }
}
