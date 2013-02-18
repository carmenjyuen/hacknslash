using UnityEngine;
using System.Collections;

public class myGUI : MonoBehaviour {
	
	public float lootWindowHeight = 90;
	private float _offset = 10;
	private const int _LOOT_WINDOW_ID = 0;
	private Rect _lootWindowRect = new Rect(0,0,0,0);
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI() {
	_lootWindowRect = GUI.Window(LOOT_WINDOW_ID, new Rect(_offset, Screen.height- (_offset + lootWindowHeight), Screen.width - (_offset *2), lootWindowHeight), LootWindow,"Loot Window");
		
	}
	private void LootWindow(int id) {
		
	}
}
