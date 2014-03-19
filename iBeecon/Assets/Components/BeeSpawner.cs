using UnityEngine;
using System.Collections;

public class BeeSpawner : MonoBehaviour {
	
	private BeaconHandler handler;

	public GameObject bee;
	public int spawnDelay = 10;
	public int beeCount = 5;

	private Time lastSpawnTime;

	private bool coroutineStarted = false;

	// Use this for initialization
	void Start () {

		handler = (BeaconHandler)GameObject.Find("Main Camera").GetComponent(typeof(BeaconHandler));
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(handler.getBeacons().Count > 0 && coroutineStarted == false){
			StartCoroutine("spawnBees");
			coroutineStarted = true;
		}
		else if(handler.getBeacons().Count == 0 && coroutineStarted == true){
			StopCoroutine("spawnBees");
			coroutineStarted = false;
		}

	}

	IEnumerator spawnBees() {
		while(true){
			yield return new WaitForSeconds(spawnDelay);
			//Spawn a bee
			GameObject b = (GameObject)GameObject.Instantiate(bee);
			b.transform.position = transform.FindChild("SpawnPosition").position;
		}
		
	}
}
