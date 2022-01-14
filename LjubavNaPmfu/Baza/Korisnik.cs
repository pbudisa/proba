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
            BlokiraniIdDrugiNavigation = new HashSet<Blokirani>();
            BlokiraniIdPrviNavigation = new HashSet<Blokirani>();
            KorisnikHobiji = new HashSet<KorisnikHobiji>();
            MatchIdDrugiNavigation = new HashSet<Match>();
            MatchIdPrviNavigation = new HashSet<Match>();
            OdbijeniIdDrugiNavigation = new HashSet<Odbijeni>();
            OdbijeniIdPrviNavigation = new HashSet<Odbijeni>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public int Dob { get; set; }
        public string Omeni { get; set; }
        public string Mobitel { get; set; }
        public string Role { get; set; }
        public int? Ids { get; set; }

        public virtual StudijskeGrupe IdsNavigation { get; set; }
        public virtual ICollection<Blokirani> BlokiraniIdDrugiNavigation { get; set; }
        public virtual ICollection<Blokirani> BlokiraniIdPrviNavigation { get; set; }
        public virtual ICollection<KorisnikHobiji> KorisnikHobiji { get; set; }
        public virtual ICollection<Match> MatchIdDrugiNavigation { get; set; }
        public virtual ICollection<Match> MatchIdPrviNavigation { get; set; }
        public virtual ICollection<Odbijeni> OdbijeniIdDrugiNavigation { get; set; }
        public virtual ICollection<Odbijeni> OdbijeniIdPrviNavigation { get; set; }
    }
}
