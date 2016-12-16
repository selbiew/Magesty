using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magesty
{
    class TargetGlyph : Glyph
    {
        public TargetGlyph(string name)
        {
            this.name = name;
            type = 3;
            manaCost = 0;
        }
    }
}
