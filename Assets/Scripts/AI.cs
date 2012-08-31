using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Movement))]
[RequireComponent (typeof(SphereCollider))]

public class AI : MonoBehaviour {
	public float preceptionRadius = 10;
	public float baseMeleeRange = 4;
	public Transform target;
	private Transform _myTransform;
	
	private const float ROTATION_DAMP = 0.3f;
	private const float FORWARD_DAMP = 0.9f;
	

		
	void Start() {
		SphereCollider sc = GetComponent<SphereCollider>();
		CharacterController cc = GetComponent<CharacterController>();
		
		if(sc == null){
			Debug.LogError("There is no spherical collider on this mob");
		}
		else {
			sc.isTrigger = true;
		}

		if(cc == null){
			Debug.LogError("There is no charactercontroller on this mob");
		}
		else {
			sc.center = cc.center;
			sc.radius = preceptionRadius;
		}
		
		_myTransform = transform;
//		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
//		if(go == null) 
//			Debug.LogError("Could not find player");
			
		
		
//		target = go.transform;
		
	}
	
	void Update() {
		if(target) {
			Vector3 dir = (target.position - _myTransform.position).normalized;
			float direction = Vector3.Dot(dir, transform.forward);
			
			
			float dist = Vector3.Distance(target.position, _myTransform.position);
			
			Debug.Log(dist);

			if(direction > FORWARD_DAMP && dist > baseMeleeRange) {
				SendMessage("MoveMeForward", Movement.Forward.forward);	
			}
			else {
				SendMessage("MoveMeForward", Movement.Forward.none);	
					
			}
	
			
			
			dir = (target.position - _myTransform.position).normalized;
			direction = Vector3.Dot(dir, transform.right);
			
			if(direction > ROTATION_DAMP) {
				SendMessage("RotateMe", Movement.Turn.right);	
			}
			
			else if(direction < -ROTATION_DAMP) {
				SendMessage("RotateMe", Movement.Turn.left);				
			}
			else {
				SendMessage("RotateMe", Movement.Turn.none);		
			}
			
		}
		else {
				SendMessage("MoveMeForward", Movement.Forward.none);	
				SendMessage("RotateMe", Movement.Turn.none);		
			
		}
	}
	
	public void OnTriggerEnter(Collider other) {
//		Debug.Log("Entered");	
		if(other.CompareTag("Player")) {
			target = other.transform;	
		}
	}
	
	public void OnTriggerExit(Collider other) {
//		Debug.Log("Exit");
		if(other.CompareTag("Player")) {
			target = null;	
		}
		
		
	}
	
}