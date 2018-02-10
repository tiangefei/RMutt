using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMissions : MonoBehaviour {
    [SerializeField] GameObject scrollView;
    private int index;
    private int size;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        index = scrollView.GetComponent<Tutorial_ScrollView>().getMissionIndex();
        size = scrollView.GetComponent<Tutorial_ScrollView>().getMissionsSize();
    }

    public void nextMission()
    {
        if(index + 1 <= size)
        {
            scrollView.GetComponent<Tutorial_ScrollView>().setCurrentMission(index + 1);
            GetComponentInParent<DisplayHandler>().ToMissionMode();
        }
    }

    public void lastMission()
    {
        if(index - 1 >= 0)
        {
            scrollView.GetComponent<Tutorial_ScrollView>().setCurrentMission(index - 1);
            GetComponentInParent<DisplayHandler>().ToMissionMode();
        }
    }
}
