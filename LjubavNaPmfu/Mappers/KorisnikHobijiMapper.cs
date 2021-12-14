using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LjubavNaPmfu.Baza;
using LjubavNaPmfu.Models;

namespace LjubavNaPmfu.Mappers
{
    public class KorisnikHobijiMapper
    {
        public static Models.KorisnikHobiji FromDatabase(Baza.KorisnikHobiji h)
        {
            return new Models.KorisnikHobiji(h.IdP, h.IdH);
        }
        public static Baza.KorisnikHobiji ToDataBase(Models.KorisnikHobiji h)
        {
            Baza.KorisnikHobiji x = new Baza.KorisnikHobiji
            {
                IdH = h.idh
            };
            if (h.idp != null)
            {
                x.IdP = (int)h.idp;
            }
            return x;
        }

    }
}
