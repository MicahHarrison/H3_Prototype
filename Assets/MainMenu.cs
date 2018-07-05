using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private SoundManager soundM;
    private string lastscene;
    public AudioClip selectsound;

    public void NewGame()
    {
        GameControl.instance.NewGame();
        Debug.Log("firstnewgame");
        GameControl.instance.pastintro = true;
        GameControl.instance.Save();
    }

    public void Play(string level)
    {
        Debug.Log(level);
        Transition.instance.FadeToLevel(level);
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

}
