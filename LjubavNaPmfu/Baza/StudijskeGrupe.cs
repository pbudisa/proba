using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LjubavNaPmfu.Baza
{
    public partial class StudijskeGrupe
    {
        public StudijskeGrupe()
        {
            Korisnik = new HashSet<Korisnik>();
        }

        public int IdG { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}
