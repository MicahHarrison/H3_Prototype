using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

    public Animator animator;
    public static Transition instance = null;     //Allows other scripts to call functions from SoundManager.             

    private string scene;

    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
        {
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);
        }
        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }


    public void FadeToLevel(string level)
    {
        scene = level;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(scene);
    }
}
