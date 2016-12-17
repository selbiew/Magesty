using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Magesty
{
    abstract public class ElementGlyph : Glyph
    {
        public int strength { get; set; }
    }

    class AirGlyph : ElementGlyph
    {
        public AirGlyph()
        {
            name = "Air";
            description = "You summon Air";
            type = 0;
            ID = 0;
            manaCost = 10;
            offPower = 2;
            defPower = 2;
            strength = 0;
        }
    }

    class WaterGlyph : ElementGlyph
    {
        public WaterGlyph()
        {
            name = "Water";
            description = "You summon Water";
            type = 0;
            ID = 1;
            manaCost = 20;
            offPower = 4;
            defPower = 4;
            strength = 0;
        }
    }

    class FireGlyph : ElementGlyph
    {
        public FireGlyph()
        {
            name = "Fire";
            description = "You summon Fire";
            type = 0;
            ID = 2;
            manaCost = 20;
            offPower = 8;
            defPower = 0;
            strength = 0;
        }
    }

    class EarthGlyph: ElementGlyph
    {
        public EarthGlyph()
        {
            name = "Earth";
            description = "You summon Earth";
            type = 0;
            ID = 3;
            manaCost = 30;
            offPower = 4;
            defPower = 6;
            strength = 0;
        }
    }

    class LightGlyph : ElementGlyph
    {
        public LightGlyph()
        {
            name = "Light";
            description = "You summon Light";
            type = 0;
            ID = 4;
            manaCost = 10;
            offPower = 0;
            defPower = 0;
            strength = 0;
        }
    }

    class DarkGlyph : ElementGlyph
    {
        public DarkGlyph()
        {
            name = "Dark";
            description = "You summon Dark";
            type = 0;
            ID = 5;
            manaCost = 10;
            offPower = 0;
            defPower = 0;
            strength = 0;
        }
    }

    class LifeGlyph : ElementGlyph
    {
        public LifeGlyph()
        {
            name = "Life";
            description = "You summon Life";
            type = 0;
            ID = 6;
            manaCost = 35;
            offPower = 0;
            defPower = 0;
            strength = 0;
        }
    }

    class DeathGlyph : ElementGlyph
    {
        public DeathGlyph()
        {
            name = "Death";
            description = "You summon Death";
            type = 0;
            ID = 7;
            manaCost = 40;
            offPower = 0;
            defPower = 0;
            strength = 0;
        }
    }

    class TimeGlyph : ElementGlyph
    {
        public TimeGlyph()
        {
            name = "Time";
            description = "You summon Time";
            type = 0;
            ID = 8;
            manaCost = 50;
            offPower = 0;
            defPower = 0;
            strength = 0;
        }
    }

    class SpaceGlyph : ElementGlyph
    {
        public SpaceGlyph()
        {
            name = "Space";
            description = "You summon Space";
            type = 0;
            ID = 9;
            manaCost = 50;
            offPower = 0;
            defPower = 0;
            strength = 0;
        }
    }

    class CheeseGlyph : ElementGlyph
    {
        public CheeseGlyph()
        {
            name = "Cheese";
            description = "You summon Cheese";
            type = 0;
            ID = 10;
            manaCost = 30;
            offPower = 1;
            defPower = 1;
            strength = 0;
        }
    }

    class CombinedGlyph : ElementGlyph
    {
        public CombinedGlyph(int newID, string name, double offPower, double defPower)
        {
            ID = newID;
            type = 0;
            this.offPower = offPower;
            this.defPower = defPower;
            this.name = name;
            Console.WriteLine("Combined Glyph Name: {0} Off: {1} Def: {2}", name, offPower, defPower);
        }
    }
}
