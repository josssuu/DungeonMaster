using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SawBlade : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -13)
        {
            transform.position = new Vector3(transform.position.x, 13f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
