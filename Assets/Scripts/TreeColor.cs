using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeColor : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        Color randomColor = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f));

       spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = randomColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
