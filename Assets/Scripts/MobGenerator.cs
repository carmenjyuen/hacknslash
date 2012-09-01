using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobGenerator : MonoBehaviour {
	public enum State {
		Idle,
		Initialize,
		Setup,
		SpawnMob
	}
	public GameObject[] mobPrefabs;		//an array to hold all of the prefabs of mobs we want to spawn
	public GameObject[] spawnPoints;	//this array will hold a reference to all of the spawnpoints in the scene
	
	public State state; 				//this is our local variable that hold our current state
	
	//called before the scripts run. Use this to make sure you have references and variables set to what are needed before the script runs
	void Awake() {
		state = MobGenerator.State.Initialize;	
	}
	
	// Use this for initialization
	IEnumerator Start () {
		while(true) {
			switch(state) {
			case State.Initialize:
				Initialize();
				break;
			case State.Setup:
				Setup();
				break;
			case State.SpawnMob:
				SpawnMob();
				break;

			}
			
			yield return 0;
		}
	}
	
	//makes sure that everything is initialized before we go on to the next step
	private void Initialize() {
//		Debug.Log("***We are in the Initialize function***");	
		
		if(!CheckForMobPrefabs())
			return;
		
		if(!CheckForSpawnPoints())
			return;
			
		state = MobGenerator.State.Setup;
	}
	
	//makes sure that everything is set up before we continue
	private void Setup() {
//		Debug.Log("***We are in the Setup function***");
		state = MobGenerator.State.SpawnMob;
	}
	
	//spawn a mob if we have an open spawn point
	private void SpawnMob() {
//		Debug.Log("***SpawnMob***");	
		GameObject[] gos = AvailableSpawnPoints();
		
		for(int cnt = 0; cnt < gos.Length; cnt++) {
			GameObject go = Instantiate(mobPrefabs[Random.Range(0,mobPrefabs.Length)],
										gos[cnt].transform.position,
										Quaternion.identity
										) as GameObject;
			go.transform.parent = gos[cnt].transform;
								
		}
		
		state = MobGenerator.State.Idle;
	}
	
	//check to see if we have atleast one mob prefab to spawn
	private bool CheckForMobPrefabs() {
		if(mobPrefabs.Length > 0)
			return true;
		else
			return false;
	}
	
	//check to see if we have atleast one spawn point to spawn mobs at
	private bool CheckForSpawnPoints() {
		if(spawnPoints.Length > 0)
			return true;
		else
			return false;
		
	}
	
	//generate a list of available spawnpoints that do not have any mobs childed to it
	private GameObject[] AvailableSpawnPoints() {
		List<GameObject> gos = new List<GameObject>();
		
		//iterate through our spawn points and add the ones that do not have a mob under it to the list
		for(int cnt = 0; cnt < spawnPoints.Length; cnt++) {
			if(spawnPoints[cnt].transform.childCount == 0) {
//				Debug.Log("*** Spawn Point Available ***");
				gos.Add(spawnPoints[cnt]);
			}
		}
		return gos.ToArray();
	}
}
