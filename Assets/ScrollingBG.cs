using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float scrollSpeed = -1.5f;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(scrollSpeed, 0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
