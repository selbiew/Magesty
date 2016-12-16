using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magesty
{
    public class Spell : Projectile                                                                         //Spells are entities that exist inside battlegrounds and interact with things upon collision
    {
        public string spellType { get; set; }                                                               //Element type, this determines strengths and weaknesses
        public string shape { get; set; }                                                                   //Lump > Wall, Wall > Fragments, Fragments more damaging that Lump.
        public string target { get; set; }                                                                  //The target the spell is going towards, determines spell velocity/direction
        public double manaCost { get; set; }                                                                
        public double offPower { get; set; }                                                                
        public double defPower { get; set; }
        public double velocity { get; set; }                                                                //Should be a 2 element double[]: [x-vel, y-vel]
        public string[] weakAgainst { get; set; }                                                           
        public string[] strongAgainst { get; set; }                                                         
        public string[] description { get; set; }                                                           //Aggregate description of each glyph in the spell parsed to be a series of sentences.
        public int nodeCount { get;  set; }

        public Spell()                                                                                      //Empty spells will not be created
        {
        }

        public Spell(SpellLinkedList spellLinkedList)                                                       //Spells are created from spellLinkedLists, iterating through nodes
        {
            manaCost = 0;
            offPower = 0;
            defPower = 0;
            nodeCount = 0;
            spellType = null;
            target = null;
            velocity = 0;
            description = new String[spellLinkedList.length+spellLinkedList.genCount]; 
            GlyphNode currentGlyph = spellLinkedList.head;
            while(currentGlyph != null)                                                                     //Iterates through spell until it has hit all nodes
            {Class1.cs
                if (currentGlyph.glyph.type == 0)                                                           //If the node contains an element change: manaCost, spellType, offPower, defPower
                {
                    manaCost += currentGlyph.glyph.manaCost;
                    spellType = currentGlyph.glyph.name;
                    offPower = currentGlyph.glyph.offPower;
                    defPower = currentGlyph.glyph.defPower;
                    if(currentGlyph.glyph.ID < 10) { description[nodeCount] = currentGlyph.glyph.description; }
                    nodeCount++;
                    currentGlyph = currentGlyph.next;
                    printSpell();
                }
                else if (currentGlyph.glyph.type == 1)                                                      //If the node contains an action
                {
                    ActionGlyph tempGlyph = (ActionGlyph)currentGlyph.glyph;
                    if (tempGlyph.numArgs == 0)                                                             //Action with 0 arguments, just changes spell values, does not return a node
                    {
                        tempGlyph.Action(this);                                                             //Interact with the spell
                        description[nodeCount] = currentGlyph.glyph.description;
                        nodeCount++;
                        currentGlyph = currentGlyph.next;                                                   //Become the next node
                    }
                    else {
                        GlyphNode newGlyph = new GlyphNode();
                        if (tempGlyph.numArgs == 1)                                                         //Action with 1 argument
                        {
                            newGlyph = tempGlyph.Action(this, currentGlyph.prev.glyph);                     //Perform action
                            if (newGlyph == null) break;
                            newGlyph.prev = currentGlyph.prev.prev;                                         //If a node is returned, put it inside the spellLinkedList
                        }

                        if (tempGlyph.numArgs == 2)                                                         //Action with 2 arguments
                        {
                            newGlyph = tempGlyph.Action(this, currentGlyph.prev.glyph, currentGlyph.prev.prev.glyph);       //Perform action
                            if (newGlyph == null) break;
                            newGlyph.prev = currentGlyph.prev.prev.prev;                                    //If a node is returned, put it inside the spellLinkedList
                        }
                        if (newGlyph.prev != null) { newGlyph.prev.next = newGlyph; }
                        else spellLinkedList.head = newGlyph;
                        newGlyph.next = currentGlyph.next;
                        if (newGlyph.next != null) { newGlyph.next.prev = newGlyph; }
                        else spellLinkedList.tail = newGlyph;
                        description[nodeCount] = currentGlyph.glyph.description;
                        nodeCount++;
                        currentGlyph = newGlyph;                                                            //CurrentGlyph becomes the returned glyph
                    }
                }
                else if (currentGlyph.glyph.type == 2) {                                                    //If the glyph contains a Shape
                    shape = currentGlyph.glyph.name;
                    description[nodeCount] = String.Format("You form it into the shape of a {0}", shape);
                    nodeCount++;
                    currentGlyph = currentGlyph.next;
                }
                else if (currentGlyph.glyph.type == 3)                                                      //If the glyph contains a Target
                {
                    target = currentGlyph.glyph.name;
                    description[nodeCount] = String.Format("and send it towards {0}", target);
                    nodeCount++;
                    currentGlyph = currentGlyph.next;
                }
            }
        }
        public void printSpell()                                                                            //Print out the values of the spell
        {
            Console.WriteLine("Type: {0} Mana: {1} Off: {2} Def: {3} Target: {4} Velocity: {5}", spellType, manaCost, offPower, defPower, target, velocity);
            for(int i = 0; i < this.nodeCount; i++)
            {
                Console.Write(description[i]);
            }
        }
    }
}
