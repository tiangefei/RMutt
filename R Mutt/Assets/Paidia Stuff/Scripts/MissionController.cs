using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// A Controller for dealing with lots of Mission objects. Not entirely sure what I need this to do yet...
public class MissionController : MonoBehaviour {

	// A list of all the current game missions.
	private Mission[] currentMissions;
	// whether or not missions have been loaded yet
	private bool missionsLoaded = false;

	// Use this for initialization
	void Start () {
		this.currentMissions = this.GetComponentsInChildren<Mission>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!missionsLoaded) {
			this.LoadMissions ();
		}
	}

	// Then the application is paused, save the missions
	void OnApplicationPause(bool isPaused) {
		if (isPaused) {
			this.SaveMissions ();
		}
	}

	// When the application loses focus, save the missions
	void OnApplicationFocus(bool hasFocus) {
		if (!hasFocus) {
			this.SaveMissions ();
		}
	}

	// When the application is quit, save the missions
	void OnApplicationQuit() {
		this.SaveMissions ();
	}

	// Returns the array of all the missions this MissionController is watching
	public Mission[] GetAllMissions(){
		return this.currentMissions;
	}

	// Saves the mission status of the missions this controller is watching
	private void SaveMissions() {
		List<SavedMission> toSave = new List<SavedMission> ();
		foreach (Mission m in this.currentMissions) {
			toSave.Add (new SavedMission (m.IsMissionComplete (), m.GetMissionName ()));
		}
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/missionSaveData.gd");
		bf.Serialize(file, toSave);
		file.Close ();
		Debug.Log ("Missions saved");
	}

	// load the saved mission data if any and returns it
	private List<SavedMission> LoadSavedMissions() {
		List<SavedMission> saveData = new List<SavedMission> ();
		if (File.Exists(Application.persistentDataPath + "/missionSaveData.gd"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/missionSaveData.gd", FileMode.Open);
			saveData = (List<SavedMission>)bf.Deserialize(file);
			file.Close();
		}
		Debug.Log ("Missions loaded");
		return saveData;
	}

	// Loads all the mission data from the saved file and makes sure the current running application is correct
	private void LoadMissions() {
		// load the missions
		List<SavedMission> saveData = this.LoadSavedMissions();

		foreach (Mission m in this.currentMissions) {
			string name = m.GetMissionName ();
			foreach (SavedMission save in saveData) {
				// if there is a saved mission for m, load it
				if (save.GetMissionName ().Equals (name)) {
					m.SetMissionCompletionStatus (save.IsMissionCompleted ());
				}
			}
		}
		this.missionsLoaded = true;
	}

	// Sets all the missions to be uncompleted. Used for testing.
	public void SetAllMissionsFalse() {
		foreach (Mission m in this.currentMissions) {
			m.SetMissionCompletionStatus(false);
		}
	}

    public int GetSize()
    {
        int i = 0;
        foreach (Mission m in this.currentMissions)
        {
            i += 1;
        }
        return i;
    }
}
