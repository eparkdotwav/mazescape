using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ColorChange();
    }

    // Update is called once per frame
    void Update()
    {
        float random = Random.Range(0f, 1f);
        if (random <= 0.005f)
        {
            ColorChange();
        }
    }

    void ColorChange()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (random <= 0.15f)
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        else if (random <= 0.5f)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (random <= 0.1f)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
