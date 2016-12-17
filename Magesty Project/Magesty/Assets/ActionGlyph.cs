using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Magesty
{
    abstract public class ActionGlyph : Glyph
    {
        public DataTable data { get; protected set; }
        public int numArgs { get; protected set; }
        virtual public void Action(Spell spell) { }
        virtual public GlyphNode Action(Spell spell, Glyph glyph) { return null; }
        virtual public GlyphNode Action(Spell spell, Glyph glyphOne, Glyph glyphTwo) { return null; }

    }

    class PushGlyph : ActionGlyph
    {
        public PushGlyph()
        {
            name = "Push";
            manaCost = 20;
            numArgs = 0;
            type = 1;
        }

        public override void Action(Spell spell)
        {
            spell.velocity = 10;
        }
    }
 
    class CombineGlyph : ActionGlyph
    {
        public CombineGlyph()
        {
            name = "Combine";
            string rootPath = @"C:\Users\Trevor\Stuff\Magesty\Magesty\Magesty\Table Generator";
            data = new DataTable(rootPath + @"\tables\elements.txt", rootPath + @"\tables\elePowers.txt", 2);
            manaCost = 1;
            numArgs = 2;
            type = 1;
        }

        public override GlyphNode Action(Spell spell, Glyph glyphOne, Glyph glyphTwo)
        {
            GlyphNode newGlyphNode = new GlyphNode();
            newGlyphNode.glyph = Combination(glyphOne, glyphTwo);
            return newGlyphNode;
        }

        private Glyph Combination(Glyph glyphOne, Glyph glyphTwo)
        {

            ElementGlyph newGlyph;
            int newID = data.returnTable[glyphOne.ID, glyphTwo.ID];
            if(newID == -1)
            {
                Console.WriteLine("Index {0}: {1} combined with Index {2}: {3}, fizzles!", glyphOne.ID, data.indexList[glyphOne.ID], glyphTwo.ID, data.indexList[glyphTwo.ID]);
                return null;
            }
           // Console.WriteLine("id_combos result: {0}", newID);
            else if (newID == glyphOne.ID)
            {
                newGlyph = (ElementGlyph)glyphOne;
                newGlyph.strength += 1;
                Console.WriteLine("Incrementing Strength");
            }
            else {
                double newOffPower = data.valueTable[0, newID];
                double newDefPower = data.valueTable[1, newID];
                string newName = data.indexList[newID];
                newGlyph = new CombinedGlyph(newID, newName, newOffPower, newDefPower);
            }
            description = String.Format("You combine {0} and {1}, forming {2}.", glyphOne.name, glyphTwo.name, newGlyph.name);
            return newGlyph;
        }
    }

}
