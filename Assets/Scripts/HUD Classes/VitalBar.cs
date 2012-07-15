/// <summary>
/// VitalBar.cs
/// Carmen Yuen
/// July 11, 2012
/// 
/// This class is reponsible for displaying the vitals bar for the player character or spawn
/// </summary>

using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {
	
	public bool _isPlayerHealthBar;		//This boolean value tells us if this is the player healthbar or the mob healthbar
	
	private int _maxBarLength; 				//How long vital bar will be at 100% capacity
	private int _curBarLength;				//The current length of the vital bar
	private GUITexture _display;			//health bar texture
	
	// Use this for initialization
	void Start () {
//		_isPlayerHealthBar = true;
		
		_display = gameObject.GetComponent<GUITexture>();
		
		_maxBarLength = (int)_display.pixelInset.width;
		
		
		OnEnable();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//This method is called when the gameObject is enabled
	public void OnEnable() {
		if(_isPlayerHealthBar)
			Messenger<int, int>.AddListener("player health update", OnChangedHealthBarLength); 
		else {
			ToggleDisplay(false);
			Messenger<int, int>.AddListener("mob health update", OnChangedHealthBarLength);
			Messenger<bool>.AddListener("show mob vital bars", ToggleDisplay);
		}
	}
	
	//This method is called when the gameObject is disabled	
	public void OnDisable() {
		if(_isPlayerHealthBar)
			Messenger<int, int>.RemoveListener("player health update", OnChangedHealthBarLength); 
		else {
			Messenger<int, int>.RemoveListener("mob health update", OnChangedHealthBarLength);
			Messenger<bool>.RemoveListener("show mob vital bars", ToggleDisplay);
		}
		
	}
	
	//this will calculate the total size of the healthbar in relation to the % of health the target has left
	public void OnChangedHealthBarLength(int curHealth, int maxHealth) {
//		Debug.Log("We heard an event - curHealth:" + curHealth + " maxHealth:" + maxHealth); 
		_curBarLength = (int)((curHealth / (float)maxHealth) *_maxBarLength);		//this calculates the current length bar length based on player's health percentage
//		_display.pixelInset = new Rect(_display.pixelInset.x, _display.pixelInset.y, _curBarLength, _display.pixelInset.height);
		_display.pixelInset = CalculatePosition();
	}
	
	//setting the healthbar to the player or mob
	public void SetPlayerHealth(bool b) {
		_isPlayerHealthBar = b;	
	}
	
	private Rect CalculatePosition() {
		float yPos = _display.pixelInset.height / 2 + 10;
		
		if(!_isPlayerHealthBar){
			float xPos = (_maxBarLength - _curBarLength) - (_maxBarLength / 4 + 10) + 350;
			return new Rect(xPos, yPos, _curBarLength, _display.pixelInset.height);		
		}
		return new Rect(_display.pixelInset.x, yPos, _curBarLength, _display.pixelInset.height);	
	}
	
	private void ToggleDisplay(bool show) {
		_display.enabled = show;
	}
}
