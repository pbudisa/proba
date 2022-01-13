using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LjubavNaPmfu.Models
{
    public class Odbijeni
    {
        public int id1 { get; set; }
        public int id2 { get; set; }

        public Odbijeni(int prvi, int drugi)
        {
            id1 = prvi;
            id2 = drugi;
        }
    }
}
