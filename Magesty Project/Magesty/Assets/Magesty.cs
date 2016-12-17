// A Hello World! program in C#.
using System;
namespace Magesty
{
    class Game
    {
        static void Main()
        {
            String spellString = getSpell();
            SpellLinkedList spell = parseSpell(spellString);
            printSpell(spell);
            Spell mySpell = new Spell(spell);
            Console.WriteLine("Final Spell");
            mySpell.printSpell();

            Console.WriteLine("Press any key to exit...");
            //Console.ReadKey();
        }

        public static string getSpell()                                   
        {
            string spellString;
            Console.Write("Enter a spell: ");
            spellString = Console.ReadLine();
            return spellString;
        }

        public static SpellLinkedList parseSpell(string spellString)
        {
            SpellLinkedList spell = new SpellLinkedList();
            char[] delimiters = { ' ', '\n', '\t' };
            string[] words = spellString.Split(delimiters);

            foreach (string s in words)
            {
                spell.addEndNode(s);
            }
            return spell;
        }

        public static string printSpell(SpellLinkedList spell)
        {
			string returnString = "";
            if (spell.head.glyph == null)
            {
                Console.WriteLine("Spell is empty");
            }
            else
            {
                GlyphNode iter = spell.head;
                int i = 0;
                while (i < spell.length)
                {
                    returnString += iter.printNode(i) + "\n";
                    iter = iter.next;
                    i++;
                }
            }
			return returnString;
        }
    }
}

 