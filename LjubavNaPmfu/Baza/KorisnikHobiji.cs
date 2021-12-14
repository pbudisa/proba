using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LjubavNaPmfu.Baza
{
    public partial class KorisnikHobiji
    {
        public int IdP { get; set; }
        public int IdH { get; set; }

        public virtual Hobi IdHNavigation { get; set; }
        public virtual Korisnik IdPNavigation { get; set; }
    }
}
