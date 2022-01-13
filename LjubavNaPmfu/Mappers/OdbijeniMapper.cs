using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LjubavNaPmfu.Models;

namespace LjubavNaPmfu.Mappers
{
    public class OdbijeniMapper
    {
        public static Odbijeni FromDatabase(Baza.Odbijeni m)
        {
            return new Odbijeni(m.IdPrvi, m.IdDrugi);
        }

        public static Baza.Odbijeni ToDatabase(Odbijeni m)
        {
            Baza.Odbijeni x = new Baza.Odbijeni
            {
                IdPrvi = m.id1,
                IdDrugi = m.id2
            };
            return x;

        }
    }
}
