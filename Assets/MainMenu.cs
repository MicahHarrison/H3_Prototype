using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void Play () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
    // Exits Game
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
