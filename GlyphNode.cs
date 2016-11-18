using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magesty
{
    public class GlyphNode
    {
        public GlyphNode prev { get; set; }
        public GlyphNode next { get; set; }
        public Glyph glyph { get; set; }

        public GlyphNode()
        {
        }

        public GlyphNode(string glyphName)
        {
            prev = null;
            next = null;
            if (glyphName == "aer") { glyph = new AirGlyph(); }
            else if (glyphName == "ignis") { glyph = new FireGlyph(); }
            else if (glyphName == "aqua") { glyph = new WaterGlyph(); }
            else if (glyphName == "massa") { glyph = new EarthGlyph(); }
            Console.WriteLine("Glyph of type: {0} added!", glyphName);
        }

        public GlyphNode(GlyphNode prev, GlyphNode next, string glyphName)
        {
            this.prev = prev;
            this.next = next;
            if(glyphName == "aer") { glyph = new AirGlyph(); }
            else if(glyphName == "ignis") { glyph = new FireGlyph(); }
            else if(glyphName == "aqua") { glyph = new WaterGlyph(); }
            else if(glyphName == "massa") { glyph = new EarthGlyph(); }
            Console.WriteLine("Glyph of type: {0} added!", glyphName);
        }

        public void printNode(int index)
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

