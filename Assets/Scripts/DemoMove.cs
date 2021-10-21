using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;


public class DemoMove : NetworkBehaviour
{



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }
}
