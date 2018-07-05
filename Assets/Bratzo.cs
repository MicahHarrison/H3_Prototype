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
        if (Input.GetKeyDown(KeyCode.E))
        {
            stare = true;
        } else
        {
            stare = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (stare && GameControl.instance.currenthealth != GameControl.instance.maxhealth)
            {
                anim.SetTrigger("Stare");
                SoundManager.instance.PlaySingle(bratz);
                GameControl.instance.currenthealth = GameControl.instance.maxhealth;
                StartCoroutine(Heal());

            }
        }
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
