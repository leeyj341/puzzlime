using System.Collections;
using System.Collections.Generic;

public class MonsterStatus
{
    private MONSTER_TYPE type = MONSTER_TYPE.NONE;

    private float origHp = 0.0f;
    private float origAtk = 0.0f;
    private float hp = 0.0f;
    private float atk = 0.0f;
    private float additionalHp = 1.0f;
    private float additionalAtk = 1.0f;
    private float speed = 0.0f;

    private float recognizedRange = 0.0f;
    private float attackRange = 0.0f;

    private Area myArea = null;

    public MONSTER_TYPE Type { get => type; set => type = value; }

    public float OrigHp { get => origHp; set => origHp = value; }
    public float OrigAtk { get => origAtk; set => origAtk = value; }
    public float Hp { get => hp; set => hp = value; }
    public float Atk { get => atk; set => atk = value; }
    public float AdditionalHp { get => additionalHp; set => additionalHp = value; }
    public float AdditionalAtk { get => additionalAtk; set => additionalAtk = value; }
    public float Speed { get => speed; set => speed = value; }

    public float RecognizedRange { get => recognizedRange; set => recognizedRange = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }

    public Area MyArea { get => myArea; set => myArea = value; }

    public MonsterStatus(MonsterInfo mInfo, Area area)
    {
        type = mInfo.Type;
        origHp = mInfo.Hp;
        origAtk = mInfo.Atk;
        speed = mInfo.Speed;
        myArea = area;
        attackRange = mInfo.AtkRange;

        recognizedRange = area.PatrolRange;
    }

    public void Reset()
    {

    }

}
