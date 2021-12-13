using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LjubavNaPmfu.Models
{
    public class Profil
    {
        public int? id_p { get; set; }
        public int id_k { get; set; }
        public string ime { get; set; }
        public int dob { get; set; }
        public string o_meni { get; set; }

        public Profil(int? p,int k,string i,int d,string o)
        {
            id_p = p;
            id_k = k;
            ime = i;
            dob = d;
            o_meni = o;
        }


    }
}
