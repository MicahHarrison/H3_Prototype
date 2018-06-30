using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    // Use this for initialization
    public void NextScene () {
        GameControl.instance.NextScene();
    }

    public void NewGame()
    {
        Debug.Log("firstnewgame");
        GameControl.instance.pastintro = true;
        GameControl.instance.Save();
    }

    public void Play()
    {
        GameControl.instance.Play();
    }

    // Exits Game
    public void Quit()
    {
        GameControl.instance.Quit();
    }
    // goes back a scene
    public void Back()
    {
        GameControl.instance.Back();

    }

}
