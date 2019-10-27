using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/BossData")]
public class BossData : ScriptableObject
{
    public BOSS_CTG Ctg;
    public float MaxHP;
    public float Atk;
    public float Speed;
    public float GroggyTime;
}
