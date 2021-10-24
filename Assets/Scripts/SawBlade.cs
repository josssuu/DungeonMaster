using UnityEngine;

public class SawBlade : MonoBehaviour
{
    public GameObject looseMenuUi;
    public GameObject winMenuUi;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -13)
        {
            SoundManager.PlaySound("sawBlade");
            transform.position = new Vector3(transform.position.x, 13f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        if (looseMenuUi.activeSelf) return;
        if (winMenuUi.activeSelf) return;
        SoundManager.PlaySound("playerHit");
        looseMenuUi.SetActive(true);
    }
}