using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject winMenuUi;
    public GameObject looseMenuUi;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        if (looseMenuUi.activeSelf) return;
        if (winMenuUi.activeSelf) return;
        SoundManager.PlaySound("door");
        winMenuUi.SetActive(true);
    }
}