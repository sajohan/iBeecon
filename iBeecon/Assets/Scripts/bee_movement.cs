using UnityEngine;
using System.Collections;

public class bee_movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//float speed = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += transform.forward * speed * Time.deltaTime;
		transform.Translate(5f * Time.deltaTime, 0f, 0f);
	}

}
