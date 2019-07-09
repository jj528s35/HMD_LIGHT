using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("MainCamera");

        if (gameObjects.Length > 0)
        {
            this.transform.position = gameObjects[0].transform.position;
        }
    }
}
