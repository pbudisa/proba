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
            KorisnikHobiji = new HashSet<KorisnikHobiji>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public int Dob { get; set; }
        public string Omeni { get; set; }
        public string Mobitel { get; set; }
        public string Role { get; set; }

        public virtual ICollection<KorisnikHobiji> KorisnikHobiji { get; set; }
    }
}
