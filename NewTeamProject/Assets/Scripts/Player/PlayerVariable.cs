using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData", menuName = "Data/PlayerData", order = 1)]
public class PlayerVariable : ScriptableObject
{
    public float PlayerHp = 10.0f;

    public void SetHp(float value)
    {
        PlayerHp += value;
    }
}
