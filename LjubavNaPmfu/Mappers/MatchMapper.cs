using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LjubavNaPmfu.Models;

namespace LjubavNaPmfu.Mappers
{
    public class MatchMapper
    {
        public static Match FromDatabase(Baza.Match m)
        {
            return new Match(m.IdPrvi, m.IdDrugi);
        }

        public static Baza.Match ToDatabase(Models.Match m)
        {
            Baza.Match x = new Baza.Match
            {
                IdPrvi = m.id1,
                IdDrugi = m.id2
            };
            return x;
           
        } 
    }
}
