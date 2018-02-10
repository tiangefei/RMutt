using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GPS : MonoBehaviour {
	public float latitude = 0;
	public float longitude = 0;
	public Text text;

	// Use this for initialization
	IEnumerator Start () {

		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser)
		{
			Debug.Log ("should ask for location");
			// remind user to enable GPS
			// As far as I know, there is no way to forward user to GPS setting menu in Unity
		}

		// Start service before querying location
		Input.location.Start();
		Debug.Log ("should start");


		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		// Service didn't initialize in 20 seconds
		if (maxWait < 1) {
			print("Timed out");
		}

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed) {
			print ("Unable to determine device location");
		}

		// Access granted and location value could be retrieved
		else {
			print ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
			latitude = Input.location.lastData.latitude;
			longitude = Input.location.lastData.longitude;
			text.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
		}

		// Stop service if there is no need to query location updates continuously
		Input.location.Stop();
	}
}