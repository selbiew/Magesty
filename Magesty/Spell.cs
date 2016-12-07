using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magesty
{
    public class Spell
    {
        public int manaCost { get; set; }
        public int offPower { get; set; }
        public int defPower { get; set; }
        public string shape { get; set; }
        public string[] weakAgainst { get; set; }
        public string[] strongAgainst { get; set; }
        public string[] description { get; set; }

        public Spell()
        {
        }

        public Spell(SpellLinkedList spellLinkedList)
        {

        }
    }
}
