using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool IsPaused = false;
    public GameObject pause;
    public Slider volumeS;
    // Use this for initialization
    void Start () {
        volumeS.value = GameControl.instance.volume;

    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Debug.Log("resume");
                Resume();
            }
            else
            {
                Debug.Log("pause");
                Pause();
            }
        }
	}

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
    public void SetVolume(float volume)
    {
        SoundManager.instance.SetVolume(volume);
    }
    public void Mute()
    {
        volumeS.value = volumeS.minValue;
        SoundManager.instance.SetVolume(-80);
    }
    public void Save()
    {
        GameControl.instance.Save();
    }
    public void WorldMap()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("World Map");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
