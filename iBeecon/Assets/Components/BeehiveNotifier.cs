using UnityEngine;
using System.Collections;

public class BeehiveNotifier : MonoBehaviour {

	public BeeSpawner beehive;


	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy(){

		if(beehive != null){

			beehive.beeWasCatched();
		}
	}

}
