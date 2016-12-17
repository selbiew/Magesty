using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Magesty
{
    abstract public class Glyph     //Each glyph needs a type (Element or Action) so it's abstract
    {
        public string name { get; protected set; }
        public string description { get; protected set; }
        public int type { get; protected set; }                     //0: Element, 1: Actions, 2: Shapes, 3: Targets
        public double manaCost { get; protected set; }              //Flat cost for Element Glyphs, Multiplier for Action Glyphs.
        public double offPower { get; protected set; }
        public double defPower { get; protected set; }
        public int ID { get; protected set; }
    }
}
