using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LjubavNaPmfu.Baza
{
    public partial class Odbijeni
    {
        public int IdPrvi { get; set; }
        public int IdDrugi { get; set; }

        public virtual Korisnik IdDrugiNavigation { get; set; }
        public virtual Korisnik IdPrviNavigation { get; set; }
    }
}
