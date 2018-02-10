using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Tutorial_ScrollView : MonoBehaviour
{
    [SerializeField] GameObject missionControl;

    public GameObject Button_Template;

    private MissionController missionController;

    private Mission[] missions = new Mission[0];

    public Mission currentMission;

    public int missionIndex;

    private bool completed = false;

    private bool GPS = false;

    private Mission[] completedMissions = new Mission[0];

	private Mission[] GPSMissions = new Mission[1];

    // Use this for initialization
    void Start()
    {
        this.missionController = this.missionControl.GetComponent<MissionController>();

        this.missions = this.missionController.GetAllMissions();

        updateList();
    }

    public void ButtonClicked(string str)
    {
        for (int i = 0; i < this.missionController.GetSize(); i++)
        {
            if (i == this.missionController.GetSize())
            {
                Debug.Log("cannot find mission " + i);
            }

            if (missions[i].GetMissionName() == str)
            {
                currentMission = missions[i];
                missionIndex = i;
                Debug.Log("1");
                GetComponentInParent<DisplayHandler>().ToMissionMode();
                Debug.Log("2");
            }

        }
    }

    public Mission getCurrentMission()
    {
        return currentMission;
    }

    public int getMissionIndex()
    {
        return this.missionIndex;
    }

    public void setCurrentMission(int i)
    {
        this.currentMission = missions[i];
        this.missionIndex = i;
    }

    public int getMissionsSize()
    {
        return this.missionController.GetSize();
    }

    private void updateList()
    {
        foreach (Mission mis in this.missions)
        {
            GameObject go = Instantiate(Button_Template) as GameObject;
            go.SetActive(true);
            Tutorial_Button TB = go.GetComponent<Tutorial_Button>();
            TB.SetName(mis.GetMissionName());
            go.transform.SetParent(Button_Template.transform.parent);
            go.transform.localScale = new Vector3(1, 1, 1);
        }

        Button_Template.SetActive(false);
    }

	private void GPSList()
	{
		getGPSMissions ();
		destoryClone ();
		print ("size: " + GPSMissions.Length);

		foreach (Mission mis in GPSMissions)
		{
			GameObject go = Instantiate(Button_Template) as GameObject;
			go.SetActive(true);
			Tutorial_Button TB = go.GetComponent<Tutorial_Button>();
			TB.SetName(mis.GetMissionName());
			TB.tag = "clone";
			go.transform.SetParent(Button_Template.transform.parent);
			go.transform.localScale = new Vector3(1, 1, 1);
		}

		Button_Template.SetActive(false);
	}

	private void BackList()
	{
		destoryClone ();
		foreach (Mission mis in this.missions)
		{
			GameObject go = Instantiate(Button_Template) as GameObject;
			go.SetActive(true);
			Tutorial_Button TB = go.GetComponent<Tutorial_Button>();
			TB.SetName(mis.GetMissionName());
			go.transform.SetParent(Button_Template.transform.parent);
			go.transform.localScale = new Vector3(1, 1, 1);
		}
		Button_Template.SetActive(false);
	}

	public void updateGPSList()
	{
		GPSList ();
	}

	public void backList()
	{
		BackList ();
	}

	public void getGPSMissions(){
		int index = 0;
		foreach(Mission mis in this.missions)
		{
			if(mis.GPS) 
			{
				GPSMissions [index] = mis;
				index++;
			}
		}
	}
		
	public void getCompletedMissions(){
		int index = 0;
		foreach (Mission mis in this.missions)
		{
			if(mis.getCompleted()) 
			{
				completedMissions[index] = mis;
				index++;
			}
		}
	}
    
	private void destoryClone() {
		foreach (Transform child in transform.GetChild(0).transform) {
			if (child.name == "Button(Clone)") {
				Destroy (child.gameObject);
			}
		}
	}
}