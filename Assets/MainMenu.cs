using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Animator transitionAnim;

    // Use this for initialization
    public void Play () {
        StartCoroutine(LoadScene());
        
	}

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        Debug.Log("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.ResetTrigger("end");
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
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
