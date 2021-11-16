using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrap : MonoBehaviour
{
    public BasicTrapData basicTrapData;

    private string TrapName;
    private Sprite TrapSprite;
    private int TrapHealth;
    private int TrapCost;
    private int TrapDamage;

    private void Awake()
    {
        LoadData();
    }

    private void LoadData()
    {
        TrapName = basicTrapData.TrapName;
        TrapSprite = basicTrapData.TrapSprite;
        TrapHealth = basicTrapData.TrapHealth;
        TrapCost = basicTrapData.TrapCost;
        TrapDamage = basicTrapData.TrapDamage;

        GetComponent<SpriteRenderer>().sprite = TrapSprite;
        RefreshCollider();
    }

    private void RefreshCollider()  // TODO Peaks olema dünaamiline, vaatab ise mis tüüpi collider on
    {
        Destroy(GetComponent<CircleCollider2D>());
        gameObject.AddComponent<CircleCollider2D>();
        GetComponent<CircleCollider2D>().isTrigger = true;  // BUG ei uuenda päriselt mängus ära
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthComponent enemyHealth = collision.GetComponent<HealthComponent>();

        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(TrapDamage);
        }
    }
}
