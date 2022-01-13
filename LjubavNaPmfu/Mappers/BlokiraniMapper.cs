using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LjubavNaPmfu.Models;

namespace LjubavNaPmfu.Mappers
{
    public class BlokiraniMapper
    {
        public static Blokirani FromDatabase(Baza.Blokirani m)
        {
            return new Blokirani(m.IdPrvi, m.IdDrugi);
        }

        public static Baza.Blokirani ToDatabase(Blokirani m)
        {
            Baza.Blokirani x = new Baza.Blokirani
            {
                IdPrvi = m.id1,
                IdDrugi = m.id2
            };
            return x;

        }
    }
}
