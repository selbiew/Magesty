using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magesty
{
    abstract public class ActionGlyph
    {
        public int numArgs { get; protected set; }
        abstract public void Action(Spell spell);
        abstract public void Action(Spell spell, Glyph glyph);
        abstract public void Action(Spell spell, Glyph glphOne, Glyph glyphTwo);

    }

    class CombineGlyph:ActionGlyph
    {
        public CombineGlyph()
        {
            numArgs = 2;

        }

        public override void Action(Spell spell)
        {

        }
    }

}
