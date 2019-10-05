using UnityEngine;

[CreateAssetMenu(menuName = "Data/MonsterData")]
public class MonsterInfo : ScriptableObject
{
    public string Name = "";

    public float Hp = 0.0f;
    public float Atk = 0.0f;
    public float Speed = 0.0f;
}
