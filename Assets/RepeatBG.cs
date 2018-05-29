using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepeatBG : MonoBehaviour
{

    private float groundHorizontalLength;
    public Canvas canvas;


    // Use this for initialization
    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        groundHorizontalLength = ((rt.rect.width * canvas.scaleFactor));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHorizontalLength/2 + 16)
        {
            RepositionBackground();
        }
    }

    public void RepositionBackground()
    {
        Vector2 groundoffset = new Vector2(groundHorizontalLength * 2f - 20, 0);
        transform.position = (Vector2)transform.position + groundoffset ;

    }
}
