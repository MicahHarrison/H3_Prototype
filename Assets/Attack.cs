using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        Player player = other.GetComponent<Player>();
        if (enemy != null)
        {
            enemy.TookDamage(GameControl.instance.currentfupa);
        }
        if (player != null)
        {
            Debug.Log("hit");
            player.TookDamage(damage);
        }
    }
}
