using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LjubavNaPmfu.Models;

namespace LjubavNaPmfu.Mappers
{
    public class ProfilMapper
    {
        public static Profil FromDatabase(Baza.Profil p)
        {
            return new Profil(p.IdP, p.IdK, p.Ime, p.Dob, p.OMeni);
        }

        public static Baza.Profil ToDatabase(Profil p)
        {
            Baza.Profil x = new Baza.Profil
            {
                IdK = p.id_k,
                Ime = p.ime,
                Dob=p.dob,
                OMeni=p.o_meni
            };
            if (p.id_p != null)
            {
                x.IdP = (int)p.id_p;
            }

            return x;
        }

    }
}
