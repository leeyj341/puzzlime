using UnityEngine;

[CreateAssetMenu(menuName = "Data/MonsterData")]
public class MonsterInfo : ScriptableObject
{
    public string PrefabName = "";                              // Prefab 이름
    public MONSTER_TYPE Type = MONSTER_TYPE.NONE;               // 몬스터의 공격 타입 

    public float Hp = 0.0f;
    public float Atk = 0.0f;
    public float Speed = 0.0f;
}
