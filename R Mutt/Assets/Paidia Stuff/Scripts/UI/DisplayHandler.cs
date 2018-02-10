using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHandler : MonoBehaviour {

	// The menu camera
	[SerializeField] Camera menuCamera;
	// The AR camera
	[SerializeField] Camera arCamera;
	// The Menu display bits
	[SerializeField] GameObject menuDisplay;
	// The Menu display bits
	[SerializeField] GameObject missionListDisplay;
	// The Menu display bits
	[SerializeField] GameObject missionDisplay;
	// The Menu display bits
	[SerializeField] GameObject cameraDisplay;
	// The current display mode
	[SerializeField] DisplayMode mode = DisplayMode.MENU;
    //
    [SerializeField] GameObject scrollViewDisplay;
    //
    [SerializeField] GameObject phone;


    // Whether or not the mode has been changed
    private bool modeChanged = true;


	// Use this for initialization
	void Start () {
		this.Update ();
	}

	// Update is called once per frame. Makes sure the approriate canvas ui is showing
	void Update () {
		if (this.modeChanged) {
			this.menuDisplay.SetActive (false);
			this.missionListDisplay.SetActive (false);
			this.missionDisplay.SetActive (false);
			this.cameraDisplay.SetActive (false);
            this.phone.SetActive (false);
			menuCamera.enabled = false;
			arCamera.enabled = false;
			switch (mode) {
			case DisplayMode.MENU:
				this.menuDisplay.SetActive (true);
				menuCamera.enabled = true;
				break;
			case DisplayMode.MISSION_SELECT:
				//this.missionListDisplay.GetComponent<MissionSelectController> ().RefreshList ();
				this.missionListDisplay.SetActive (true);
				menuCamera.enabled = true;
				break;
			/**case DisplayMode.MISSION:
				this.missionDisplay.SetActive (true);
				this.missionDisplay.GetComponent<MissionDisplay> ().SetMission 
					(this.missionListDisplay.GetComponent<MissionSelectController> ().GetCurrentlySelectedMission ());
				menuCamera.enabled = true;
				break;*/
            case DisplayMode.MISSION:
                this.missionDisplay.SetActive(true);
                this.missionDisplay.GetComponent<MissionDisplay>().SetMission
                    (this.scrollViewDisplay.GetComponent<Tutorial_ScrollView>().getCurrentMission());
                menuCamera.enabled = true;
                break;
            case DisplayMode.CAMERA:
			    this.cameraDisplay.SetActive (true);
				arCamera.enabled = true;
				break;
            case DisplayMode.PHONE:
                    this.phone.SetActive(true);
                    menuCamera.enabled = true;
                    break;
            }
			this.modeChanged = false;
		}
	}

	// Set the mode to menu
	public void ToMenuMode() {
		this.modeChanged = true;
		this.mode = DisplayMode.MENU;
		menuCamera.enabled = true;
		arCamera.enabled = false;
	}

	// Set the mode to mission select
	public void ToMissionSelectMode() {
		this.modeChanged = true;
		this.mode = DisplayMode.MISSION_SELECT;
	}

	// Set the mode to a single mission
	public void ToMissionMode() {
		this.modeChanged = true;
		this.mode = DisplayMode.MISSION;
	}

	// Set the mode to the camera mode
	public void ToCameraMode() {
		this.modeChanged = true;
		this.mode = DisplayMode.CAMERA;
		arCamera.enabled = true;
		menuCamera.enabled = false;
	}

    public void ToPhoneMode()
    {
        this.modeChanged = true;
        this.mode = DisplayMode.PHONE;
    }
}

// An enum for the display mode
public enum DisplayMode {
	MENU, MISSION_SELECT, MISSION, CAMERA, PHONE
}
