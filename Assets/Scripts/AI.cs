using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Movement))]
[RequireComponent (typeof(SphereCollider))]

public class AI : MonoBehaviour {
	
	private enum State {
		Idle,		//do nothing
		Init,		//make sure everything we need is here
		Setup,		//assign values to things we need
		Search,		//find the player
		Attack,		//attack the player
		Retreat,	//retreat to spawn point
		Flee		// go to nearest spawn point next to next mob
	}
	
	public float perceptionRadius = 10;
	public float baseMeleeRange = 4;
	public Transform target;
	private Transform _myTransform;
	
	private const float ROTATION_DAMP = 0.3f;
	private const float FORWARD_DAMP = 0.9f;
	
	private Transform _home;
	private State _state;
	private bool _alive = true;
	private SphereCollider _sphereCollider;
		
	void Start() {
		_state = AI.State.Init;
		StartCoroutine("FSM");
/*		SphereCollider sc = GetComponent<SphereCollider>();
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
			sc.radius = perceptionRadius;
		}
*/
		
		
//		_myTransform = transform;
//		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
//		if(go == null) 
//			Debug.LogError("Could not find player");
			
		
		
//		target = go.transform;
		
	}
	
	private IEnumerator FSM() {
		while(_alive) {
			Debug.Log("Alive?:" + _alive);
			switch(_state) {
			case State.Init:
				Init();
				break;
			case State.Setup:
				Setup();
				break;
			case State.Search:
				Search();
				break;
			case State.Attack:
				Attack();
				break;
			case State.Retreat:
				Retreat();
				break;
			case State.Flee:
				Flee();
				break;
			}
			yield return null;
		}
	}
	
	private void Init() {
		Debug.Log("Init");
		
		_myTransform = transform;
		_home = transform.parent.transform;
		_sphereCollider = GetComponent<SphereCollider>();
		
		if(_sphereCollider == null) {
			Debug.LogError("Sphere Collider not present.");
			return;
		}
		
		_state = AI.State.Setup;
	}
	private void Setup() {
		Debug.Log("Setup");
		_sphereCollider.center = GetComponent<CharacterController>().center;
		_sphereCollider.radius = perceptionRadius;
		_sphereCollider.isTrigger = true;
		
		_state = AI.State.Search;
		_alive = false;
	}	
	private void Search() {
		Debug.Log("Search");	
		
		Move();
		_state = AI.State.Attack;
	}	
	private void Attack() {
		Debug.Log("Attack");
		
		Move();
		_state = AI.State.Retreat;
	}
	private void Retreat() {
		Debug.Log("Retreat");
		_myTransform.LookAt(target);
		Move();
		_state = AI.State.Search;
	}	
	
	private void Flee() {
		Debug.Log("Flee");
		
		Move();
		_state = AI.State.Search;
	}	
	
/*	
	void Update() {
		
	}
	
*/
	
	
	private void Move() {
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
			_alive = true;
			StartCoroutine("FSM");
		}
	}
	
	public void OnTriggerExit(Collider other) {
//		Debug.Log("Exit");
		if(other.CompareTag("Player")) {
			target = _home;	
//			_alive = false;
		}
		
		
	}
	
}
