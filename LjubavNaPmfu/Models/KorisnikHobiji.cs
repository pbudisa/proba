using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LjubavNaPmfu.Models
{
    public class KorisnikHobiji
    {
        public int? idp { get; set; }
        public int idh { get; set; }

        public KorisnikHobiji(int? p,int h)
        {
            idp = p;
            idh = h;
        }
    }
}
