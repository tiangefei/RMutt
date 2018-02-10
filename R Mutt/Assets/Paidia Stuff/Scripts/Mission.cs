using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// A Mission for the R Mutt game. A Mission should be attached to a game object that has an AReward and/or an ARestriction.
public class Mission : MonoBehaviour {

	// The name for this mission
	public string missionName;
	// The image for this mission
	public Sprite imageReward;
	// The text for this mission
	public string textReward = "";
	// the test for the mission hint
	public string missionHint = "...";
	// Whether or not this Missions was completed before
	private bool isCompleted;

	public bool GPS;

	// Use this for initialization
	void Start () {
		this.isCompleted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isCompleted || this.IsMissionComplete ()) {
			this.isCompleted = true;
		}
	}

	// Returns whether or not this Mission-GameObject is complete
	public bool IsMissionComplete() {
		if (this.isCompleted) {
			return true;
		}
		ARestriction[] restrictions = this.GetComponents<ARestriction> ();
		if (restrictions.Length == 0) {
			return true;
		}
		bool completed = true;
		for (int idx = 0; idx < restrictions.Length; idx++) {
			completed = completed && restrictions [idx].IsRestrictionMet ();
		}
		return completed;
	}

	// Sets the status of the Mission to be the given value
	public void SetMissionCompletionStatus(bool status) {
		this.isCompleted = status;
	}

	// Gets the name for this Mission if any
	public string GetMissionName() {
		return this.missionName;
	}

	// Returns an Image reward for this Mission (if applicable)
	public Sprite GetMissionImage() {
		return this.imageReward;
	}

	// Returns the mission text for this Mission (if applicable)
	public string GetMissionText() {
		return this.textReward;
	}

	// Returns the mission hint for this Mission
	public string GetMissionHint() {
		return missionHint;
	}

	// Plays an audio clip associated with this mission (if applicable)
	public void PlayMissionAudio() {
	}

    public bool getCompleted()
    {
        return isCompleted;
    }

}

// Used to save the data for missions in a serializable form. Missions are saved as a name and completion status value
[System.Serializable]
public class SavedMission {
	private bool missionCompleted;
	private string missionName;

	public SavedMission (bool missionCompleted, string missionName) {
		this.missionCompleted = missionCompleted;
		this.missionName = missionName;
	}

	public bool IsMissionCompleted() {
		return this.missionCompleted;
	}

	public string GetMissionName() {
		return this.missionName;
	}
}
