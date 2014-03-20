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
					//Debug.Log ("I'm hitting the " + hit.collider.name);
					if(hit.transform.gameObject.tag.Equals("Bee")){
						Destroy(hit.transform.gameObject);
					}

				}
			}
						
		}

		if (Input.GetMouseButtonDown(0)) {

			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//Debug.Log(pos.ToString());
			RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);
			if (hit != null && hit.collider != null) {
				//Debug.Log ("I'm hitting the " + hit.collider.name);
				if(hit.transform.gameObject.tag.Equals("Bee")){
					Destroy(hit.transform.gameObject);
				}
			}

			
		}
		
		/*if(Input.GetMouseButtonDown(0)){
			Debug.Log(Input.mousePosition.ToString());
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log(pos.ToString());
			Vector2 mousePos = new Vector2 (pos.x, pos.y);
			//RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);
			if (collider2D == Physics2D.OverlapPoint(mousePos)) {
				Debug.Log ("I'm hitting the " + gameObject.name);
				Destroy(gameObject);
			}

		}*/



		//Input.GetTouch(0).deltaPosition
	}
}