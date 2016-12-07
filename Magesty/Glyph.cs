using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magesty
{
    abstract public class Glyph     //Each glyph needs a type (Element or Action) so it's abstract
    {
        public string name { get; protected set; }
        public int type { get; protected set; }     //0: Element, 1: One argument Actions, 2: Two argument Actions, 3: Targets?
        public int manaCost { get; protected set; }
        public int ID { get; protected set; }
    }
}
