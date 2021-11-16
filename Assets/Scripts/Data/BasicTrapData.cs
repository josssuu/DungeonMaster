using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/BasicTrapData")]
public class BasicTrapData : ScriptableObject
{
    public string TrapName;
    public Sprite TrapSprite;
    public int TrapHealth;
    public int TrapCost;
    public int TrapDamage;
}
