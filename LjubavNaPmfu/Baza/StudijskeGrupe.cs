using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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
