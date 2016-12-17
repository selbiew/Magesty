using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Magesty
{
    public class SpellLinkedList                                                                           //A doubly linked list of nodes that contain glyphs
    {  
        public GlyphNode head;                                                                             //Head is the first node (word put in), tail is the last, length is the number of nodes
        public GlyphNode tail;
        public int length { get; protected set; }
        public int genCount { get; protected set; }

        public SpellLinkedList()                                                                           //Constructor for SpellLinkedLists
        {
            head = new GlyphNode();
            tail = new GlyphNode();
            length = 0;
            genCount = 0;
            Console.WriteLine("spellLinkedList Created!");
        }

        public void addEndNode(string glyphName)                                                           //Add head first, then tail, then adds nodes to end and they become the new tail
        {
            if (head.glyph == null)                                                                        //Sets the head if there isn't one
            {
                head = new GlyphNode(glyphName);
                head.prev = null;
                head.next = null;
                length = 1;
                if (glyphName == "combinus") { genCount++; }
                Console.WriteLine("Head is now: {0}", head.glyph.name);
            }

            else if (tail.glyph == null)                                                                    //Sets the tail if there isn't one
            {
                tail = new GlyphNode(glyphName);
                head.next = tail;
                tail.prev = head;
                tail.next = null;
                length = 2;
                if (glyphName == "combinus") { genCount++; }
                Console.WriteLine("Head is: {0} Tail is now: {1}", head.glyph.name, tail.glyph.name);
            }

            else                                                                                            //Add an end node, this new node is the new tail
            {
                GlyphNode newNode = new GlyphNode(glyphName);                                               //Add a node of name glyphName
                newNode.prev = tail;
                newNode.next = null;
                tail.next = newNode;
                tail = newNode;
                length++;
                if (glyphName == "combinus") { genCount++; }                                               // Combinus means a new node will be created from the previous two
                if (newNode.glyph != null)
                {
                   Console.WriteLine("GlyphNode added of piece: {0}!", newNode.glyph.name);
                }
            }
        }

    }
}
