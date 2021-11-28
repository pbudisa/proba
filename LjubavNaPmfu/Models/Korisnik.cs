using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LjubavNaPmfu.Models
{
    public class Korisnik
    {
        public int? id { get; set; }
        public string username { get; set; }
        public string lozinka { get; set; }
        public string role { get; set; }

        public Korisnik(int? i,string u,string l,string r)
        {
            id = i;
            username = u;
            lozinka = l;
            role = r;
        }
    }
}
