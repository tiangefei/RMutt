using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraDeviceMode : MonoBehaviour {
	
	// Refocus the camera when the screen is tapped on on Update
	void Update () {
		if (Input.GetTouch(Input.touchCount - 1).phase == TouchPhase.Began) {
			CameraDevice.Instance.SetFocusMode(
				CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
			Debug.Log ("Camera Focused");
		}
	}
}
