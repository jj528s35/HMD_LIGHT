using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift_Buttom : MonoBehaviour {
    private int appnum = 0;
    public static int shiftnum = 0;
    public GameObject[] buttomlist;
    private GameObject UI;
    // Use this for initialization
    void Start () {
        UI = gameObject.transform.parent.gameObject;
        appnum = UI.transform.childCount - 2;
        buttomlist = new GameObject[appnum];

        for (int i = 0; i < appnum; i++)
        {
            buttomlist[i] = UI.gameObject.transform.GetChild(i).gameObject;
            if (i > 0)
                buttomlist[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShiftAPP(bool IsRight)
    {
        if (IsRight)
        {
            int currentAPPindex = shiftnum % appnum;
            GameObject currentAPP = buttomlist[currentAPPindex];
            currentAPP.SetActive(false);

            shiftnum++;
            currentAPPindex = shiftnum % appnum;
            currentAPP = buttomlist[currentAPPindex];
            currentAPP.SetActive(true);
        }
        else
        {
            int currentAPPindex = shiftnum % appnum;
            GameObject currentAPP = buttomlist[currentAPPindex];
            currentAPP.SetActive(false);

            shiftnum--;
            if (shiftnum < 0) shiftnum += appnum;
            currentAPPindex = shiftnum % appnum;
            currentAPP = buttomlist[currentAPPindex];
            currentAPP.SetActive(true);
        }
    }
}
