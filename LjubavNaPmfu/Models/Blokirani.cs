using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LjubavNaPmfu.Models
{
    public class Blokirani
    {
        public int id1 { get; set; }
        public int id2 { get; set; }

        public Blokirani(int prvi, int drugi)
        {
            id1 = prvi;
            id2 = drugi;
        }
    }
}
