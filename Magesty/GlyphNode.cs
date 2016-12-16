using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magesty
{
    public class GlyphNode                                                                                  //Glyphnodes making up a doubly linked list, each carries a glyph
    {
        public GlyphNode prev { get; set; }
        public GlyphNode next { get; set; }
        public Glyph glyph { get; set; }

        public GlyphNode()                                                                                  //Glyphnode must be instantiated with a glyph inside
        {
        }

        public GlyphNode(string glyphName)                                                                  //Instantiate glyphNodes with glyph depending on magic word
        {
            prev = null;
            next = null;
            switch(glyphName)                                                                               //Creates nodes with different glyphs dependent upon magic word
            {
                case "aer":
                    glyph = new AirGlyph();
                    break;
                case "aqua":
                    glyph = new WaterGlyph();
                    break;
                case "ignis":
                    glyph = new FireGlyph();
                    break;
                case "massa":
                    glyph = new EarthGlyph();
                    break;
                case "lux":
                    glyph = new LightGlyph();
                    break;
                case "tenebris":
                    glyph = new DarkGlyph();
                    break;
                case "vita":
                    glyph = new LifeGlyph();
                    break;
                case "mortem":
                    glyph = new DeathGlyph();
                    break;
                case "tempus":
                    glyph = new TimeGlyph();
                    break;
                case "vacuo":
                    glyph = new SpaceGlyph();
                    break;
                case "cheesus":
                    glyph = new CheeseGlyph();
                    break;
                case "combinus":
                    glyph = new CombineGlyph();
                    break;
                case "trudo":
                    glyph = new PushGlyph();
                    break;
                case "aliud":
                    glyph = new TargetGlyph("Enemy");
                    break;
                default:
                    Console.WriteLine("That's not a real glyph dude");
                    break;

            }
            Console.WriteLine("Glyph of type: {0} added!", glyphName);
        }

        public void printNode(int index)                                                                    //Prints the values of the node, or if it's null
        {
            if (this.glyph != null)
            {
                Console.WriteLine("Index: {2} Spellpiece: {0} Type: {1}: ", glyph.name, glyph.type, index);
            }
            else
            {
                Console.WriteLine("This node is null!");
            }
        }

    }
}

