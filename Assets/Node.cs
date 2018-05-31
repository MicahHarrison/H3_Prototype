using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {


    public PathFollow move;
    // Use this for initialization
    void OnMouseDown()
    {
       Vector3 position = transform.position;
       move.ClickMove(position);

    }
    
}
