using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APP_Manager : MonoBehaviour {
    public Camera cam;
    private GameObject return_buttom;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(cam.gameObject);

        return_buttom = GameObject.Find("return");
        DontDestroyOnLoad(return_buttom.gameObject);
        return_buttom.SetActive(false);
    }
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        //return_buttom.SetActive(true);
    }

    public void Return_click()
    {
        return_buttom.SetActive(true);
    }
}
