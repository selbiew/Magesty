using UnityEngine;
using System.Collections;
using Magesty;

public class Display : MonoBehaviour {
	
	int width = 400;
	int height = 600;
	int w_x;
	int w_y;
	string glyphString = "";
	string displayString = "";
	string battleString = "";
	Battleground battleground;
	Spell mySpell;
	SpellLinkedList spell;
	Rect displayWindow;
	// Use this for initialization
	void Start () {
		SetGUILayout();
		battleground = new Battleground(10,10);
		//Game.Main();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateSpell();
	}
	
	void UpdateSpell () {
		string newstring = "";
		foreach (char c in Input.inputString) {
			if (c == ' ' || c == '\r'){ //if space or enter
				glyphString += newstring;
				//do stuff with the glyph here instead of the following five lines
				spell = Game.parseSpell(glyphString);
				displayString = Game.printSpell(spell);
				mySpell = new Spell(spell);
				displayString += mySpell.printSpell();
				glyphString = "";
				newstring = "";
			}
			else {
				if (c != "\n"[0] && c != "\b"[0]){ //these shouldn't come up but just in case
					newstring += c;
				}
			}
			
		}
		glyphString += newstring;
	}
	
	void OnGUI() {
		displayWindow = GUI.Window(0,displayWindow,DisplayWindow,"Magesty");
	}
	
	void DisplayWindow(int windowID){
		GUI.Box(new Rect(5,25,390,20),glyphString);
		/*if (Input.GetKeyDown(KeyCode.Return)){
			spell = Game.parseSpell(glyphString);
			displayString = Game.printSpell(spell);
			mySpell = new Spell(spell);
			displayString += mySpell.printSpell();
			glyphString = "";
		*/
		GUI.Box(new Rect(5,75,390,200),displayString);
		if (battleString == "") battleString = battleground.printBattleground();
		GUI.Box(new Rect(5,280,390,200),battleString);
	}
	
	void SetGUILayout(){
		width = 400;
		height = 600;
		w_x = (Screen.width - width)/2;
		w_y = (Screen.height - height)/2;
		displayWindow = new Rect(w_x,w_y,width,height);
	}
}
