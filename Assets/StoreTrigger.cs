using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreTrigger : MonoBehaviour {

    public Player player;
    public string scene;
    public bool trackposition;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transition.instance.FadeToLevel(scene);
        }
    }
    void Update()
    {
        if (trackposition) { 
            GameControl.instance.playerposition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 5);
        }
    }
}
