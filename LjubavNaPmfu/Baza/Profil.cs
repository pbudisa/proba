using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LjubavNaPmfu.Baza
{
    public partial class Profil
    {
        public Profil()
        {
            KorisnikHobiji = new HashSet<KorisnikHobiji>();
        }

        public int IdP { get; set; }
        public int IdK { get; set; }
        public string Ime { get; set; }
        public int Dob { get; set; }
        public string OMeni { get; set; }

        public virtual Korisnik IdKNavigation { get; set; }
        public virtual ICollection<KorisnikHobiji> KorisnikHobiji { get; set; }
    }
}
