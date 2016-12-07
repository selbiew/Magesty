using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magesty
{
    abstract public class ElementGlyph : Glyph
    {
        public int offPower { get; protected set; }
        public int defPower { get; protected set; }
    }

    class AirGlyph : ElementGlyph
    {
        public AirGlyph()
        {
            name = "Air";
            type = 0;
            ID = 0;
            manaCost = 10;
            offPower = 2;
            defPower = 2;
        }
    }

    class WaterGlyph : ElementGlyph
    {
        public WaterGlyph()
        {
            name = "Water";
            type = 0;
            ID = 1;
            manaCost = 20;
            offPower = 4;
            defPower = 4;
        }
    }

    class FireGlyph : ElementGlyph
    {
        public FireGlyph()
        {
            name = "Fire";
            type = 0;
            ID = 2;
            manaCost = 20;
            offPower = 8;
            defPower = 0;
        }
    }

    class EarthGlyph: ElementGlyph
    {
        public EarthGlyph()
        {
            name = "Earth";
            type = 0;
            ID = 3;
            manaCost = 30;
            offPower = 6;
            defPower = 6;
        }
    }
}
