using UnityEngine;

public enum UpgradeType
{
    MovementSpeedUpgrade,
    JumpHeightUpgrade
}

public class Upgrade : MonoBehaviour
{
    public UpgradeType UpgradeType;
    public Sprite newSprite;

    void Start()
    {
        UpgradeType = (UpgradeType) Random.Range(0, 2);
        if (UpgradeType == UpgradeType.JumpHeightUpgrade) gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Warrior_Sheet-Effect_0")
        {
            if (UpgradeType == UpgradeType.JumpHeightUpgrade)
                collision.gameObject.GetComponent<CharacterController2D>().m_JumpForce += 100f;
            collision.gameObject.GetComponent<PlayerMovement>().runSpeed += 10f;
            gameObject.SetActive(false);
        }
    }
}