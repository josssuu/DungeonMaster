using MLAPI;
using UnityEngine;

public class DemoMove : NetworkBehaviour
{
    public float speed = 25.0f;

    private void Start()
    {
        transform.position = new Vector3(-21.0f, 0f);
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime *
                           speed;
        transform.position += movement;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -22.2f, 22.2f),
            Mathf.Clamp(transform.position.y, -10.3f, 11f),
            0);
    }
}