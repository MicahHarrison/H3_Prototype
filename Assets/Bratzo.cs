using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bratzo : MonoBehaviour
{

    public AudioClip bratz, heal;
    public Animator anim;

    private bool stare;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && stare && GameControl.instance.currenthealth != GameControl.instance.maxhealth)
        {
            anim.SetTrigger("Stare");
            SoundManager.instance.PlaySingle(bratz);
            GameControl.instance.currenthealth = GameControl.instance.maxhealth;
            StartCoroutine(Heal());

        }
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(stare);
        stare = true;
    }

    void OnCollisionExit(Collision other)
    {
        stare = false;
    }

    IEnumerator Heal()
    {
        yield return new WaitForSeconds(3f);
        FindObjectOfType<UIManager>().UpdateHealth(GameControl.instance.currenthealth);
        SoundManager.instance.PlaySingle(heal);
    }

    public void Back(string level)
    {
        {
            Transition.instance.FadeToLevel(level);
        }
    }
}
