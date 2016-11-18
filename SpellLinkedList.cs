using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magesty
{
    public class SpellLinkedList
    {
        public GlyphNode head;
        public GlyphNode tail;
        public int length { get; protected set; }

        public SpellLinkedList()
        {
            head = new GlyphNode();
            tail = new GlyphNode();
            length = 0;
            Console.WriteLine("spellLinkedList Created!");
        }

        public void addEndNode(string glyphName)
        {
            if (head.glyph == null)
            {
                head = new GlyphNode(glyphName);
                head.prev = null;
                head.next = null;
                length = 1;
                Console.WriteLine("Head is now: {0}", head.glyph.name);
            }

            else if (tail.glyph == null)
            {
                tail = new GlyphNode(glyphName);
                head.next = tail;
                tail.prev = head;
                tail.next = null;
                length = 2;
                Console.WriteLine("Head is: {0} Tail is now: {1}", head.glyph.name, tail.glyph.name);
            }

            else
            {
                GlyphNode newNode = new GlyphNode(glyphName);
                newNode.prev = tail;
                newNode.next = null;
                tail.next = newNode;
                tail = newNode;
                length++;
                Console.WriteLine("GlyphNode added of piece: {0}!", newNode.glyph.name);
            }
        }

    }
}
