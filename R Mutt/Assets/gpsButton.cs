using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gpsButton : MonoBehaviour {
	public Tutorial_ScrollView ScrollView;
	bool mark = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void click() {
		if (mark == false) {
			ScrollView.updateGPSList ();
			mark = true;
		} else {
			ScrollView.backList ();
			mark = false;
		}
	}	
}
