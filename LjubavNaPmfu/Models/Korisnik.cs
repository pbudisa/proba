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
        public string ime { get; set; }
        public int dob { get; set; }
        public string omeni{ get;set; }
        public string mob { get; set; }

        public Korisnik(int? i, string u, string l, string r, string im, int d, string o, string mo)
        {
            id = i;
            username = u;
            lozinka = l;
            role = r;
            ime = im;
            dob = d;
            omeni = o;
            mob = mo;
        }
    }
}
