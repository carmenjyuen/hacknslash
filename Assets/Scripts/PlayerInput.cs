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
		

		
		if(Input.GetButtonDown("Rotate Player")) {
			if(Input.GetAxis("Rotate Player") > 0) {
				SendMessage("RotateMe", Movement.Turn.right);	
			}
			else {
				SendMessage("RotateMe", Movement.Turn.left);
			}
		}
		
		if(Input.GetButtonUp("Rotate Player")) {
			SendMessage("RotateMe", Movement.Turn.none);	
		}

		
		if(Input.GetButtonDown("Strafe")) {
			if(Input.GetAxis("Strafe") > 0) {
				SendMessage("Strafe", Movement.Turn.right);	
			}
			else {
				SendMessage("Strafe", Movement.Turn.left);
			}
		}
		
		if(Input.GetButtonUp("Strafe")) {
			SendMessage("Strafe", Movement.Turn.none);	
		}		
		
		if(Input.GetButton("Jump")) {
			SendMessage("JumpUp");
		}
		
		if(Input.GetButtonDown("Run")) {
			SendMessage("ToggleRun");	
		}
	}
	
}

