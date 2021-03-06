using UnityEngine;
using System.Collections;
using Vuforia;

public class GameController : MonoBehaviour {

	// Start the game controller
	void Start() {
		this.StartLocationServices ();
	}

	// Starts the location services for the device
	IEnumerator StartLocationServices() {
		// If location services not enabled, print that it isn't on.
		if (!Input.location.isEnabledByUser) {
			print("Location services not enabled by user."
				+ " For full functionality, please turn location services on and restart the application.");
			yield break;
		}

		// Start service before querying location
		// the first param is the accuracy in meters, the second is the frequency of updates in meters
		Input.location.Start(1, 1);

		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		// Service didn't initialize in 20 seconds
		if (maxWait < 1)
		{
			print("Timed out");
			yield break;
		}
		// Connection has failed
		else if (Input.location.status == LocationServiceStatus.Failed)
		{
			print("Unable to determine device location");
			yield break;
		}
			
		// if reached here, location services should be working
		print("Location Stuff working");
	}

}
