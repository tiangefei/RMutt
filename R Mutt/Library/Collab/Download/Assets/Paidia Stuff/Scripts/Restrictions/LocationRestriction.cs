using UnityEngine;
using System.Collections;

public class LocationRestriction : ARestriction {

	// The latitude for this LocationRestriction.
	public float latitude;
	// The longitude for this LocationRestriction.
	public float longitude;
	// The allowed error for this LocationRestriction (ex. .001 means the latitude and longitude may be off by at most .001)
	public float allowedError;

	// Returns if the user is at the right latitude and longitude within the error margin
	override public bool IsRestrictionMet()  {
		if (!Input.location.isEnabledByUser) {
			return false;
		}

        print(Input.location);

		float longitudeError = Mathf.Abs (this.longitude - Input.location.lastData.longitude);
		float latitudeError = Mathf.Abs (this.latitude - Input.location.lastData.latitude);

		return (longitudeError <= allowedError && latitudeError <= allowedError);

	}

}
