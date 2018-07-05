using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

    public int[] coinvalue;
    public AudioClip coinsound;

    private float rotation;

	// Use this for initialization
	void Awake () {
        rotation = Random.Range(0.2f, 0.7f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, rotation, 0, Space.World);
	}

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("MONIES");
            GameControl.instance.currency += coinvalue[Random.Range(0, coinvalue.Length)];
            Destroy(gameObject);
            SoundManager.instance.PlaySingle(coinsound);
        }
    }
}
