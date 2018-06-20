using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy {

    public GameObject boomerang;

	// Use this for initialization
	void Awake () {
		
	}
	
    void ThrowBoomerang()
    {
        if (!isDead)
        {
            anim.SetTrigger("Boomerang");
        }
    }
	
}
