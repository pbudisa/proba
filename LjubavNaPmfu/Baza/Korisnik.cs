using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LjubavNaPmfu.Baza
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Profil = new HashSet<Profil>();
        }

        public int IdK { get; set; }
        public string Username { get; set; }
        public string Lozinka { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Profil> Profil { get; set; }
    }
}
