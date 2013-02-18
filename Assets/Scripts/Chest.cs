using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {
	
	public enum State {
		open,
		close,
		inbetween
	}
	
	public AudioClip openSound;
	public AudioClip closeSound;
	
	public State state;
	
	// Use this for initialization
	void Start () {
		state = Chest.State.close;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public void OnMouseEnter() {
		Debug.Log("Enter");	
	}
	
	public void OnMouseExit() {
		Debug.Log("Exit");	
	}
	public void OnMouseUp() {
		Debug.Log("Up");	
		switch(state) {
		case State.open:
			state = Chest.State.inbetween;
			StartCoroutine("Close");
			break;
		case State.close:
			state = Chest.State.inbetween;
			StartCoroutine("Open");
			break;
		}
//		if(state == Chest.State.close)
//			Open();
//		else 
//			Close();
	}
	
	private IEnumerator Open() {
		animation.Play("open");
		audio.PlayOneShot(openSound);
		yield return new WaitForSeconds(animation["open"].length);
		state = Chest.State.open;
	}
	
	private IEnumerator Close() {
		animation.Play("close");
		audio.PlayOneShot(closeSound);	
		yield return new WaitForSeconds(animation["close"].length);
		state = Chest.State.close;
	}
	
}
