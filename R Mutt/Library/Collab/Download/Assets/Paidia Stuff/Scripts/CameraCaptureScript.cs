using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCaptureScript : MonoBehaviour {

	private string screenshotPrefix = "R_MUTT_";
	private string extension = ".png";

	public void Capture() {
		string timestamp = "" + System.DateTime.Now.Month + System.DateTime.Now.Day + System.DateTime.Now.Year 
			+ System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second;
		Application.CaptureScreenshot (screenshotPrefix + timestamp + extension);
	}

}
