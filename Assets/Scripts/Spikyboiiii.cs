using UnityEngine;

public class Spikyboiiii : MonoBehaviour
{
    public GameObject looseMenuUi;
    public GameObject winMenuUi;

    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-34f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * (speed), 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        if (looseMenuUi.activeSelf) return;
        if (winMenuUi.activeSelf) return;
        //SoundManager.PlaySound("playerHit");
        looseMenuUi.SetActive(true);
    }
}