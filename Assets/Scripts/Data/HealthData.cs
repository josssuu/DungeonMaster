using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/HealthData")]
public class HealthData : ScriptableObject
{
    public int MaxHealth;
    public int HealthRegenPerSec;
}
