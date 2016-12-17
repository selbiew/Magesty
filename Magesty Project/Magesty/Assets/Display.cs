using UnityEngine;
using System.Collections;
using Magesty;

public class Display : MonoBehaviour {
	
	int width = 400;
	int height = 600;
	int w_x;
	int w_y;
	string spellString = "";
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
	
	}
	
	void OnGUI() {
		displayWindow = GUI.Window(0,displayWindow,DisplayWindow,"Magesty");
	}
	
	void DisplayWindow(int windowID){
		spellString = GUI.TextField(new Rect(5,25,390,20),spellString);
		if (GUI.Button(new Rect(150,50,100,20),"Enter Spell") || Input.GetKeyDown(KeyCode.Return)){
			spell = Game.parseSpell(spellString);
			displayString = Game.printSpell(spell);
			mySpell = new Spell(spell);
			displayString += mySpell.printSpell();
			spellString = "";
		}
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
