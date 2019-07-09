using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttom : MonoBehaviour {

	private bool Colorchanged = false;
	private float timer = 0.0f;
    private GameObject APP_list,cam;
    private GameObject manager;
	
	// Use this for initialization
	void Start () {
        APP_list = GameObject.Find("APP_list");
        cam = GameObject.Find("Camera");
        manager = GameObject.Find("Network");
    }
	
	// Update is called once per frame
	void Update () {
		if(Colorchanged) timer += Time.deltaTime;

		if (GetComponent<Renderer>().material.color == Color.green && Colorchanged == false)
		{
			Colorchanged = true;
			timer = 0.0f;
		}

		if (timer > 1)
		{
			timer = 0;
			Colorchanged = false;
			GetComponent<Renderer>().material.color = Color.gray;
		}

	}

	public void ClickButton()
	{
		if(name == "leftshift")
            GetComponent<Shift_Buttom>().ShiftAPP(false);
		else if(name == "rightshift")
            GetComponent<Shift_Buttom>().ShiftAPP(true);
        else if (name == "return")
            SceneManager.LoadScene("APP_scene");
        else
        {
            GetComponent<Renderer>().material.color = Color.green;
            string APP_name = gameObject.transform.GetChild(0).gameObject.name;
            SceneManager.LoadScene(APP_name);

            //APP_list.SetActive(false);
            manager.GetComponent<APP_Manager>().Return_click();
            //cam.transform.position = GameObject.Find("MainCamera").transform.position;
        }
       
    }

}
