using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Movement))]
[RequireComponent (typeof(SphereCollider))]

public class AI : MonoBehaviour {
	public Transform target;
	private Transform _myTransform;
	
	void Start() {
		_myTransform = transform;
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		if(go == null)
			Debug.LogError("Could not find player");
		
		target = go.transform;
	}
	
	void Update() {
		if(target) {
			Vector3 dir = (target.position - _myTransform.position).normalized;
			float direction = Vector3.Dot(dir, transform.forward);
			
			if(direction > .9f) {
				SendMessage("MoveMeForward", Movement.Forward.forward);	
			}
			else {
				SendMessage("MoveMeForward", Movement.Forward.none);	
				
			}
		}
	}
	
}
