using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class myGUI : MonoBehaviour {
	public float lootWindowHeight = 90;
	
	public float buttonWidth = 40;
	public float buttonHeight = 40;
	public float closeButtonWidth = 20;
	public float closeButtonHeight = 20;
	
	private List<Item> _lootItems;
	private bool _displayLootWindow = true;
	private float _offset = 10;
	private const int _LOOT_WINDOW_ID = 0;
	private Rect _lootWindowRect = new Rect(0,0,0,0);
	private Vector2 _lootWindowSlider = Vector2.zero;
	
	// Use this for initialization
	void Start () {
		_lootItems = new List<Item>();
		
		Populate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI() {
		if(_displayLootWindow)
				
			_lootWindowRect = GUI.Window(_LOOT_WINDOW_ID, new Rect(_offset, Screen.height- (_offset + lootWindowHeight), Screen.width - (_offset *2), lootWindowHeight), LootWindow,"Loot Window");
		
	}
	private void LootWindow(int id) {
		if(GUI.Button(new Rect(_lootWindowRect.width - 20, 0, closeButtonWidth, closeButtonHeight), "x")) {
			_displayLootWindow = false;
		}
		_lootWindowSlider = GUI.BeginScrollView(new Rect(_offset * .5f, 15, _lootWindowRect.width - 10, 70), _lootWindowSlider, new Rect(0, 0, (_lootItems.Count * buttonWidth) + _offset, buttonHeight + _offset));
		
		for(int cnt = 0; cnt < _lootItems.Count; cnt++) {
			GUI.Button(new Rect(5 + (buttonWidth * cnt), _offset, buttonWidth, buttonHeight),cnt.ToString());
		}	
	
		GUI.EndScrollView();
	}
	
	private void Populate() {
		for(int cnt = 0; cnt < 25; cnt++)
			_lootItems.Add(new Item());
	}
}
