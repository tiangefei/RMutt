using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionDisplay : MonoBehaviour {

	// The Text object for the name of the mission
	[SerializeField] Text nameText;
	// The Image to display the mission image to
	[SerializeField] Image missionImage;
	// The Text object for the mission flavor text
	[SerializeField] Text missionText;
	// The default sprite to use when a mission has no Sprite
	[SerializeField] Sprite defaultSprite;

	// the currently displayed Mission
	private Mission curMission = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (curMission) {
			this.UpdateName ();
			this.UpdateImage ();
			this.UpdateText ();
		} else {
			this.nameText.text = "Unknown";
			this.missionImage.sprite = this.defaultSprite;
			this.missionText.text = "...";
		}
	}

	// Sets the current mission to be the given one.
	public void SetMission(Mission mission) {
		this.curMission = mission;
	}

	// Updates the name text to use the mission's name
	private void UpdateName() {
		string name = curMission.GetMissionName ();
		if (curMission.IsMissionComplete ()) {
			name += " (Complete)";
		}
		this.nameText.text = name;
	}

	// Updates the image to use the sprite of the current mission if applicable
	private void UpdateImage() {
		if (curMission.IsMissionComplete() && curMission.GetMissionImage ()) {
			this.missionImage.sprite = this.curMission.GetMissionImage ();
		} else {
			this.missionImage.sprite = this.defaultSprite;
		}
	}

	// Updates the flavor text to use the current mission's
	private void UpdateText() {
		if (curMission.IsMissionComplete ()) {
			this.missionText.text = this.curMission.GetMissionText ();		
		} else {
			this.missionText.text = this.curMission.GetMissionHint ();
		}
	}

    public Mission getCurrentMission()
    {
        return curMission;
    }
}
