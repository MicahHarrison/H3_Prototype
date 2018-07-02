using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreTrigger : MonoBehaviour {

    public Player player;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Shop");
        }
    }
    void Update()
    {
        GameControl.instance.playerposition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

    }
}
