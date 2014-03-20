using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class BeaconHandler : MonoBehaviour {

	//Example of return value from native
	//[{"major":100,"minor":10,"uuid":"BE5D05DF-3075-4DE2-95D2-D946525B7885","accuracy":0.02782559401302485,"rssi":-31,"proximity":0}]

	public ArrayList beacons;

	/*----------------- Native Functions -----------------*/

	[DllImport ("__Internal")]
	private static extern void initBeaconManager();
	[DllImport ("__Internal")]
	private static extern void monitorRegionWithUUID(string uuid);

	/*----------------------------------------------------*/

	void Start(){
		if(this.beacons == null){
			beacons = new ArrayList();
		}
		//updateBeaconData("[{\"major\":1,\"minor\":1,\"uuid\":\"BE5D05DF-3075-4DE2-95D2-D946525B7885\",\"accuracy\":0.4641588833612779,\"rssi\":-53,\"proximity\":1}]");

#if UNITY_IPHONE && !UNITY_EDITOR
		this.initIBeacon();
#endif
	}
	
	public void initIBeacon(){
		Debug.Log("Init in Unity");
		string uuid = "BE5D05DF-3075-4DE2-95D2-D946525B7885";


		initBeaconManager();
		monitorRegionWithUUID(uuid);

		updateBeaconData("[{\"major\":1,\"minor\":1,\"uuid\":\"BE5D05DF-3075-4DE2-95D2-D946525B7885\",\"accuracy\":0.4641588833612779,\"rssi\":-53,\"proximity\":1}]");
	}

	public void updateBeaconData(string beaconJSON){

		if(this.beacons == null){
			beacons = new ArrayList();
		}
		JSONObject jsonObj = new JSONObject(beaconJSON);
		//Loop through each beacon
		foreach(JSONObject b in jsonObj.list){
			Beacon beacon = new Beacon(b.GetField("uuid").str, (int)b.GetField("major").n, (int)b.GetField("minor").n, (int)b.GetField("proximity").n, (double)b.GetField("accuracy").n, (int)b.GetField("rssi").n);
			
			//Check if beacon already exists. If it doesn't exist add it to the list. If it exists update the ranging values.
			Beacon tmp = this.getBeacon(beacon);
			if(tmp == null){
				Debug.Log("New Beacon!");
				beacons.Add(beacon);
			}else{
				Debug.Log("Beacon already exists!");
				tmp.updateRangingData(beacon.proximity, beacon.accuracy, beacon.rssi);
			}
		}
		//GameObject camera = GameObject.Find("Main Camera");
		//((BeaconGUI)camera.GetComponent(typeof(BeaconGUI))).jsonLabelText = beaconJSON;
	}


	public Beacon getBeacon(Beacon beacon){

		foreach(Beacon b in beacons){
			if(b.sameAsBeacon(beacon)){
				return b;
			}
		}
		return null;

	}

	private bool beaconExists(Beacon beacon){
		foreach(Beacon b in beacons){
			if(b.sameAsBeacon(beacon)){
				return true;
			}
		}
		return false;
	}


	public ArrayList getBeacons(){
		return beacons;
	}
}
