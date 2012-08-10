using UnityEngine;
using System.Collections;

public class HackAndSlashCamera : MonoBehaviour {
	public Transform target;
	public float walkDistance;
	public float runDistance;
	public float height;
	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;
	
	
	private Transform _myTransform;
	private float _x;
	private float _y;
	private bool _camButtonDown = false;
	
		
	// Use this for initialization
	void Start() {
		if(target == null)
			Debug.LogWarning("There is no camera target");
		
		_myTransform = transform;
		CameraSettup();
	}
	
	void Update() {
		if(Input.GetMouseButtonDown(1)) {  //Use the Input Manager to make this user selectable 
			_camButtonDown = true;
		}
		if(Input.GetMouseButtonUp(1)){
			_camButtonDown = false;
		}
			
	}

	void LateUpdate() {
		
		if(target != null) {
			if(_camButtonDown) {
				
				_x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
				_y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
			
				Quaternion rotation = Quaternion.Euler(_y, _x, 0);
				Vector3 position = rotation * new Vector3(0.0f, 0.0f, -walkDistance) + target.position;
			
				_myTransform.rotation = rotation;
				_myTransform.position = position;
			}
			else {
				_x = 0;  //reset the x value	
				_y = 0;  //reset the y value
				
				//Calculate the current rotation angles
				float wantedRotationAngle = target.eulerAngles.y;
				float wantedHeight = target.position.y + height;
				
				float currentRotationAngle = _myTransform.eulerAngles.y;
				float currentHeight = _myTransform.position.y;
				
				//Damp the rotation around the y-axis
				currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
				
				//Damp the height
				currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
				
				//Convert the andle into a rotation
				Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
				
				//Set the position of the camera on the x-z plane to distance meters behind the target
				_myTransform.position = target.position;
				_myTransform.position -= currentRotation * Vector3.forward * walkDistance;
				
				//Set the height of the camera
				_myTransform.position = new Vector3(_myTransform.position.x, currentHeight, _myTransform.position.z);
				
				//Always look at the target
				_myTransform.LookAt(target);
				
				
			}
		}
	}
	
	public void CameraSettup() {
		_myTransform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - walkDistance);
		_myTransform.LookAt(target);
	
	}
}

