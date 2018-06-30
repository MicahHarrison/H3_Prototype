using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUp : MonoBehaviour {

    public GameObject NewGameTop;
    public GameObject NewGameMiddle;
    public GameObject Play;

	// Use this for initialization
	void Start () {
		if (GameControl.instance.isSave())
        {
            Debug.Log(Application.persistentDataPath + "/playerinfo.dat");
            NewGameTop.SetActive(true);
            NewGameMiddle.SetActive(false);
            Play.SetActive(true);
        }
        else
        {
            NewGameTop.SetActive(false);
            NewGameMiddle.SetActive(true);
            Play.SetActive(false);
        }
	}
}
