using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LjubavNaPmfu.Baza
{
    public partial class Hobi
    {
        public Hobi()
        {
            KorisnikHobiji = new HashSet<KorisnikHobiji>();
        }

        public int IdH { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<KorisnikHobiji> KorisnikHobiji { get; set; }
    }
}
