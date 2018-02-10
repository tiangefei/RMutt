using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionSelectController : MonoBehaviour {

    // A dropdown menu to use for mission selection
    [SerializeField] Dropdown missionDropdown;
	// The mission managing object
	[SerializeField] GameObject missionControl;
	// the mission controller from missionControl
	private MissionController missionController;
	// the missions in this mission select
	private Mission[] missions = new Mission[0];

	void OnEnable() {
		InvokeRepeating ("RefreshList", 0, 3);
	}

	// Returns the Mission that is currently selected by the user
	public Mission GetCurrentlySelectedMission() {
		return this.missions [this.missionDropdown.value];
	}

	// Refresh the contents of the list when it needs to be updated
	public void RefreshList() {
		this.missionController = this.missionControl.GetComponent<MissionController> ();
		this.missions = this.missionController.GetAllMissions ();
		this.missionDropdown.ClearOptions ();
		List<string> names = new List<string> ();
		foreach (Mission m in this.missions) {
			if (m.IsMissionComplete ()) {
				names.Add (m.GetMissionName () + " (Complete)");
			} else {
				names.Add (m.GetMissionName());
			}
		}
		this.missionDropdown.AddOptions (names);
	}
}
