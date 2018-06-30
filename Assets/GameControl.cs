using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
    //player prefs
    public int reswidth;
    public int resheight;
    public bool fullScreen;
    public float volume;
    public int quality;
    public static GameControl instance = null;     //Allows other scripts to call functions from GameControl. 

    //player stats
    public int maxhealth;
    public float currency;

    //player progress
    public bool pastintro;


    // Use this for initialization
    void Awake () {
        //Check if there is already an instance of GameControl
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
        {
            Debug.LogError("New GameController");
            //Destroy this, this enforces our singleton pattern so there can only be one instance of GameControl.
            Destroy(gameObject);
        }
        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }
	
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        Debug.Log("Saved");
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");

        PlayerData data = new PlayerData();
        data.reswidth = reswidth;
        data.resheight = resheight;
        data.fullScreen = fullScreen;
        data.volume = volume;
        data.quality = quality;

        data.maxhealth = maxhealth;
        data.currency = currency;

        data.pastintro = pastintro;


        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            Debug.Log("Loaded");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);

            PlayerData data = (PlayerData) bf.Deserialize(file);
            file.Close();
            reswidth = data.reswidth;
            resheight = data.resheight;
            fullScreen = data.fullScreen;
            volume = data.volume;
            quality = data.quality;

            maxhealth = data.maxhealth;
            currency = data.currency;

            pastintro = data.pastintro;

        }
    }

    public bool isSave()
    {
        return File.Exists(Application.persistentDataPath + "/playerinfo.dat");
    }

    // Use this for initialization
    public void NextScene()
    {
        StartCoroutine(LoadScene());
    }
    public void Play()
    {
        StartCoroutine(LoadMap());
    }

    IEnumerator LoadScene()
    {
      
        Debug.Log("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator LoadMap()
    {
        Debug.Log("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("World Map");
    }

    // Exits Game
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    // Exits Game
    public void Back()
    {
        StartCoroutine(BackLoadScene());

    }

    IEnumerator BackLoadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }
}


[Serializable]
class PlayerData
{
    public int reswidth;
    public int resheight;
    public bool fullScreen;
    public float volume;
    public int quality;

    public int maxhealth;
    public float currency;

    public bool pastintro;
}
