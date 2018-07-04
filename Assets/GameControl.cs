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
    public int lives = 3;
    public int maxhealth;
    public int maxfupa;
    public int currenthealth;
    public int healthlvl = 1;
    public int currentfupa;
    public int fupalvl = 1;
    public float currency = 0;

    //player progress
    public bool pastintro;
    public Vector3 playerposition = new Vector3(-7, 3, -4);

    // max stats
    public int maxhealthlvl = 5;
    public int maxfupalvl = 5;


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
	
    public void NewGame()
    {
        File.Delete(Application.persistentDataPath + "/playerinfo.dat");
        if (isSave())
        {
            Debug.Log("not deleted");
        }else
        {
            Debug.Log("deleted");
        }
        currency = 0;
        lives = 3;
        Save();
        Load();
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

        data.lives = lives;
        data.maxhealth = maxhealth;
        data.healthlvl = healthlvl;
        data.maxfupa = maxfupa;

        data.fupalvl = fupalvl;
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

            lives = data.lives;
            maxhealth = data.maxhealth;
            currenthealth = data.maxhealth;
            healthlvl = data.healthlvl;
            maxfupa = data.maxfupa;
            currentfupa = data.maxfupa;
            fupalvl = data.fupalvl;
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
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator LoadMap()
    {
        Debug.Log("end");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("World Map");
    }

    // Exits Game
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    // back to menu
    public void Back()
    {
        StartCoroutine(BackLoadScene());

    }

    IEnumerator BackLoadScene()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Menu");
    }
    public void Prev()
    {
        StartCoroutine(PrevLoadScene());

    }

    IEnumerator PrevLoadScene()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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

    public int lives;
    public int maxhealth;
    public int maxfupa;
    public int healthlvl;
    public int fupalvl;
    public float currency;

    public bool pastintro;
}
