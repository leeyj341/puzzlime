using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager Instance;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }

    public static void GetDamaged(ref float hp, float atk)
    {
        hp -= atk;
        if (hp <= 0.0f) hp = 0.0f;
    }
}
