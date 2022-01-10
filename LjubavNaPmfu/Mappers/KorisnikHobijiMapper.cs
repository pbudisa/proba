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
            return new Models.KorisnikHobiji(h.Idk, h.Idh);
        }
        public static Baza.KorisnikHobiji ToDataBase(Models.KorisnikHobiji h)
        {
            Baza.KorisnikHobiji x = new Baza.KorisnikHobiji
            {
                Idh = h.idh,
                Idk=h.idp
            };
            
            return x;
        }

    }
}
