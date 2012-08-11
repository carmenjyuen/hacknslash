using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class Movement : MonoBehaviour {
	public float moveSpeed = 3;
	public float runMultiplier = 2;
	public float strafeSpeed = 2.5f;
	public float rotateSpeed = 250;
	private Transform _myTransform;
	private CharacterController _controller;
	
	public void Awake() {
		_myTransform = transform;
		_controller = GetComponent<CharacterController>();
	}
	
	//Use this for initialization
	void Start() {
		animation.wrapMode = WrapMode.Loop;
	}
	
	//Update is called once per frame 
	void Update() {
		Turn();
		Walk();
		Strafe();
				

	}
		
	private void Turn() {
		if(Mathf.Abs(Input.GetAxis("Rotate Player")) > 0){
			_myTransform.Rotate(0, Input.GetAxis("Rotate Player") * Time.deltaTime * rotateSpeed, 0);	
		}	
	}
	
	private void Walk(){
		if(Mathf.Abs(Input.GetAxis("Move Forward")) > 0){
//			Debug.Log("Forward" + Input.GetAxis("Move Forward"));
			if(Input.GetButton("Run")) {
				animation.CrossFade("run");
				_controller.SimpleMove(_myTransform.TransformDirection(Vector3.forward)* Input.GetAxis("Move Forward") * moveSpeed * runMultiplier);
				
			}
			else { 
				animation.CrossFade("walk");
				_controller.SimpleMove(_myTransform.TransformDirection(Vector3.forward)* Input.GetAxis("Move Forward") * moveSpeed);
			}
			
		}
		else {
			animation.CrossFade("idle");
		}
	}
	
	private void Strafe(){
		if(Mathf.Abs(Input.GetAxis("Strafe")) > 0){
//			Debug.Log("Strafe" + Input.GetAxis("Strafe"));
			_controller.SimpleMove(_myTransform.TransformDirection(Vector3.right)* Input.GetAxis("Strafe") * strafeSpeed);
		}
	}
	
}