using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Movement))]
public class PlayerInput : MonoBehaviour {
	
	void Start () {
	}
	
	void Update () {
		if(Input.GetButtonDown("Move Forward")) {
			if(Input.GetAxis("Move Forward") > 0) {
				SendMessage("MoveMeForward", Movement.Forward.forward);	
			}
			else {
				SendMessage("MoveMeForward", Movement.Forward.back);
			}
		}
		
		if(Input.GetButtonUp("Move Forward")) {
			SendMessage("MoveMeForward", Movement.Forward.none);	
		}
		
		if(Input.GetButtonDown("Run")) {
			SendMessage("ToggleRun");	
		}
	}
	
}

