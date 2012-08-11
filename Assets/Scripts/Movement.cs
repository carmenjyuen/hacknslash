using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class Movement : MonoBehaviour {
	public float moveSpeed = 5;
	public float rotateSpeed = 250;
	private Transform _myTransform;
	private CharacterController _controller;
	
	public void Awake() {
		_myTransform = transform;
		_controller = GetComponent<CharacterController>();
	}
	
	//Use this for initialization
	void Start() {
		
	}
	
	//Update is called once per frame 
	void Update() {
		if(Mathf.Abs(Input.GetAxis("Rotate Player")) > 0){
			_myTransform.Rotate(0, Input.GetAxis("Rotate Player") * Time.deltaTime * rotateSpeed, 0);	
		}
		
		if(Mathf.Abs(Input.GetAxis("Move Forward")) > 0){
//			Debug.Log("Forward" + Input.GetAxis("Move Forward"));
			_controller.SimpleMove(_myTransform.TransformDirection(Vector3.forward)* Input.GetAxis("Move Forward") * moveSpeed);
		}
	}
		
	
	
}