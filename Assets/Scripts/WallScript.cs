using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.magenta;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Color(128 / 255.0f, 121 / 255.0f, 121 / 255.0f);
    }
}
