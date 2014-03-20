using UnityEngine;
using System.Collections;

public class Beacon{

	public enum Proximity {Immediate=0, Near, Far, Unknown};


	public string uuid;
	public int major;
	public int minor;
	public Proximity proximity;
	public double accuracy;
	public int rssi;


	public Beacon(string uuid, int major, int minor){

		this.uuid = uuid;
		this.major = major;
		this.minor = minor;
		this.proximity = Proximity.Unknown;
		this.accuracy = -1;
		this.rssi = -1;


	}

	public Beacon(string uuid, int major, int minor, int prox, double accuracy, int rssi){
		this.uuid = uuid;
		this.major = major;
		this.minor = minor;
		this.accuracy = accuracy;
		this.rssi = rssi;
		switch(prox){
		case 0:
			proximity = Proximity.Immediate;
			break;
		case 1:
			proximity = Proximity.Near;
			break;
		case 2:
			proximity = Proximity.Far;
			break;
		case 3:
			proximity = Proximity.Unknown;
			break;
			
		}
	}


	public Beacon(string uuid, int major, int minor, Proximity prox, double accuracy, int rssi){
		this.uuid = uuid;
		this.major = major;
		this.minor = minor;
		this.proximity = prox;
		this.accuracy = accuracy;
		this.rssi = rssi;
	}

	public void updateRangingData(Proximity proximity, double accuracy, int rssi){
		this.proximity = proximity;
		this.accuracy = accuracy;
		this.rssi = rssi;

	}


	public bool sameAsBeacon(Beacon b){
		if(this.uuid.Equals(b.uuid) && major==b.major && minor==b.minor){
			return true;
		}else{
			return false;
		}

	}
	
	public override string ToString ()
	{
		return string.Format ("[Beacon: uuid={0}, major={1}, minor={2}, proximity={3}, accuracy={4}, rssi={5}]", uuid, major, minor, proximity, accuracy, rssi);
	}
	
}
