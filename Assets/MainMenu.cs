using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private SoundManager soundM;
    public AudioClip selectsound;

    // Use this for initialization
    public void NextScene () {
        GameControl.instance.NextScene();
    }

    public void NewGame()
    {
        GameControl.instance.NewGame();
        Debug.Log("firstnewgame");
        GameControl.instance.pastintro = true;
        GameControl.instance.Save();
    }

    public void Play()
    {
        Transition.instance.FadeToLevel("World Map");
        //GameControl.instance.Play();
    }
    public void SelectSound()
    {
        SoundManager.instance.PlaySingle(selectsound);
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
