using UnityEngine;
using System.Collections;

public class BeeTouch : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.touchCount > 0) {
			for(int i=0; i<Input.touchCount; i++) {
				Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
				RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);
				if (hit != null && hit.collider != null) {
					Debug.Log ("I'm hitting the " + hit.collider.name);
					
				}
			}
						
		}
		//Input.GetTouch(0).deltaPosition
	}
}