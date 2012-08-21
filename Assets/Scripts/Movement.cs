using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class Movement : MonoBehaviour {
	public enum Turn {
		left = -1,
		none = 0,
		right =1
	}
	
	public enum Forward {
		back = -1,
		none = 0,
		forward = 1
	}
	

	
	public CollisionFlags _collisionFlags;		//the collision flags we have from the last frame
	private Vector3 _moveDirection;
	
	
	public float walkSpeed = 3;
	public float runMultiplier = 2;
	public float strafeSpeed = 2.5f;
	public float rotateSpeed = 200;
	public float gravity = 20;			//setting for gravity
	public float airTime = 0;			//how long have we been in the air since the last time on the ground
	public float fallTime = .5f;		//the length of time we have to be falling to kow it is falling.
	public float jumpHeight = 5;		//the height we move when we are jumping
	public float jumpTime = 1.5f;		
	
	private Transform _myTransform;
	private CharacterController _controller;
	
	private Turn _turn;
	private Forward _forward;
	private bool _run;
	private bool _jump;
	private Turn _strafe;
	
	public void Awake() {
		_myTransform = transform;
		_controller = GetComponent<CharacterController>();
	}
	
	//Use this for initialization
	void Start() {
		
		_moveDirection = Vector3.zero;
		
		animation.Stop();

		animation.wrapMode = WrapMode.Loop;
		
		animation["idle"].layer = 1;
		animation["idle"].wrapMode = WrapMode.Once;
		
		animation.Play("idle");
		
		Init();
		
	}
	
	void Update() {
		ActionPicker();	
	}
	
	private void Init() {
		_turn = Movement.Turn.none;
		_forward = Movement.Forward.none;
		_strafe = Movement.Turn.none;
		_run = false;
		_jump = false;
	}
	
	private void ActionPicker() {
		_myTransform.Rotate(0, (int)_turn * Time.deltaTime * rotateSpeed, 0);	
		
	
		
		if(_controller.isGrounded) {
			Debug.Log("On the ground");
			airTime = 0;
			
			_moveDirection = new Vector3((int)_strafe, 0, (int)_forward);
			_moveDirection = _myTransform.TransformDirection(_moveDirection).normalized;
			_moveDirection *= walkSpeed;
			
			if(_forward != Forward.none) {
				if(_run) {
					_moveDirection *= runMultiplier;
					Run();
				}
				else {
					Walk();
				}
					
			}
			else if(_strafe != Movement.Turn.none) {
				Strafe();	
			}
			else {
				Idle();	
			}
			
			if(_jump) {
				if(airTime < jumpTime) {
					_moveDirection.y += jumpHeight;
					Jump();
					_jump = false;
				}
			}
		}
		else {
			Debug.Log("Not on the ground");
			
			if((_collisionFlags & CollisionFlags.CollidedBelow) == 0) {
				airTime += Time.deltaTime;
				
				if(airTime > fallTime) {
					Fall();		
				}
			}
		}
		
		_moveDirection.y -= gravity * Time.deltaTime;
		_collisionFlags = _controller.Move(_moveDirection * Time.deltaTime);
		
				

		
	}
	
	public void MoveMeForward(Forward z) {
		_forward = z;	
	}
	
	public void ToggleRun() {
		_run = !_run;	
	}
	
	public void RotateMe(Turn y) {
		_turn = y;	
	}
	
	public void Stafe(Turn x) {
		_strafe = x;	
	}
	
	public void JumpUp() {
		_jump = true;
	}
	
	public void Idle() {
		animation.CrossFade("idle");
	}
	
	public void Walk() {
		animation.CrossFade("walk");
	}
	
	public void Run() {
		animation["run"].speed = 1.5f;
		animation.CrossFade("run");
	}

	public void Jump() {
		animation.CrossFade("idle");
	}
	
	public void Strafe() {
		animation.CrossFade("walk");
	}
	
	public void Fall() {
		animation.CrossFade("idle");
	}
	
}