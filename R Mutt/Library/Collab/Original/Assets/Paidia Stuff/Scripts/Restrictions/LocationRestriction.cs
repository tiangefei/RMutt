using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class LocationRestriction : ARestriction {

	// The latitude for this LocationRestriction.
	public float setlatitude;
	// The longitude for this LocationRestriction.
	public float setlongitude;
	// The allowed error for this LocationRestriction (ex. .001 means the latitude and longitude may be off by at most .001)
	public float allowedError;

	public float latitude;

	public float longitude;

	public static LocationRestriction Instance { set; get;}

	public void start() {
		Instance = this;
		DontDestroyOnLoad (gameObject);
		StartCoroutine (StartLocationService ());
	}

	private IEnumerator StartLocationService() {
		if (!Input.location.isEnabledByUser) {
			yield break;
		}

		Input.location.Start ();
		int MaxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && MaxWait > 0) {
			yield return new WaitForSeconds (1);
			MaxWait--;
		}

		if(MaxWait <= 0)
		{
			yield break;
		}

		if(Input.location.status == LocationServiceStatus.Failed) {
			yield break;
		}

		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;
	}


	// Returns if the user is at the right latitude and longitude within the error margin
	override public bool IsRestrictionMet()  {
		
		float longitudeError = Mathf.Abs (this.setlongitude - this.longitude);
		float latitudeError = Mathf.Abs (this.setlatitude - this.latitude);

		return (longitudeError <= allowedError && latitudeError <= allowedError);
	}

}
