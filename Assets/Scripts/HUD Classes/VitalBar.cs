/// <summary>
/// VitalBar.cs
/// Carmen Yuen
/// July 11, 2012
/// Carmen Yuen
/// 
/// This class is reponsible for displaying the vitals bar for the player character or spawn
/// </summary>

using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {
	
	private bool _isPlayerHealthBar;		//This boolean value tells us if this is the player healthbar or the mob healthbar

	// Use this for initialization
	void Start () {
		_isPlayerHealthBar = true;
		
		OnEnable();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//This method is called when the gameObject is enabled
	public void OnEnable() {
		
	}
	
	//This method is called when the gameObject is disabled	
	public void OnDisable() {
		
	}
	
	//this will calculate the total size of the healthbar in relation to the % of health the target has left
	public void ChangeHealthBarSize(int curHealth, int maxHealth) {
		
	}
	
	//setting the healthbar to the player or mob
	public void SetPlayerHealth(bool b) {
		_isPlayerHealthBar = b;	
	}
}
