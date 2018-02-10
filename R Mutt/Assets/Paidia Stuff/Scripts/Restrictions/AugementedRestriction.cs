using UnityEngine;
using System.Collections;

// A Restriction that checks if the given target is currently being rendered.
// This can be used with game objects that are targets for the Vuforia SDK.
public class AugementedRestriction : ARestriction {

	// The Augmenets Reality target that this Restriction is checking for
	public GameObject augmentedRealityTarget;

	override public bool IsRestrictionMet() {
		return this.augmentedRealityTarget.GetComponent<Renderer> ().enabled;
	}
}
