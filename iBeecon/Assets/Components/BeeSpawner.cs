using UnityEngine;
using System.Collections;

public class BeeSpawner : MonoBehaviour {
	
	private BeaconHandler handler;
	
	public GameObject beePrefab;
	public int spawnDelay = 5;
	public int beeCount = 5;
	private int beesCatched = 0;

	private ArrayList spawnedBees;

	//Information about which beacon that spawns the bees
	public string uuid;
	public int majorValue;
	public int minorValue;
	private Beacon beacon;

	private GameObject catchedBeesLabel;
	
	private bool coroutineStarted = false;

	// Use this for initialization
	void Start () {

		beacon = new Beacon(uuid, majorValue, minorValue);
		((SpriteRenderer)gameObject.GetComponent("SpriteRenderer")).enabled = false;
	
		spawnedBees = new ArrayList();
		catchedBeesLabel = gameObject.transform.Find("CatchedBeesLabel").gameObject;
		catchedBeesLabel.transform.position = Camera.main.WorldToViewportPoint(catchedBeesLabel.transform.position);
		catchedBeesLabel.guiText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(handler == null){
			handler = (BeaconHandler)GameObject.Find("Main Camera").GetComponent("BeaconHandler");
			//Debug beacon
			//handler.beacons.Add(new Beacon("BE5D05DF-3075-4DE2-95D2-D946525B7885", 1, 1, Beacon.Proximity.Near, 0, 0));
		}
		Beacon b = handler.getBeacon(beacon);
		if(b != null){
			if((b.proximity == Beacon.Proximity.Immediate || b.proximity == Beacon.Proximity.Near) && coroutineStarted == false){
				StartCoroutine("spawnBees");
				coroutineStarted = true;
				((SpriteRenderer)gameObject.GetComponent("SpriteRenderer")).enabled = true;
				catchedBeesLabel.guiText.enabled = true;
			}else if((b.proximity == Beacon.Proximity.Far || b.proximity == Beacon.Proximity.Unknown) && coroutineStarted == true){
				StopCoroutine("spawnBees");
				coroutineStarted = false;
				((SpriteRenderer)gameObject.GetComponent("SpriteRenderer")).enabled = false;
				catchedBeesLabel.guiText.enabled = false;
			}
		}


	}

	public void beeWasCatched(){

		beesCatched++;
		//Debug.Log("Bees catched: " + beesCatched);
		catchedBeesLabel.guiText.text = "Catched bees: " + beesCatched;
	}


	IEnumerator spawnBees() {
		while(true){
			yield return new WaitForSeconds(spawnDelay);
			//Spawn a bee
			GameObject b = (GameObject)GameObject.Instantiate(beePrefab);
			b.transform.position = gameObject.transform.Find("SpawnPosition").position;

			spawnedBees.Add(b);
			((BeehiveNotifier)b.GetComponent("BeehiveNotifier")).beehive = this;
		}
		
	}
}
