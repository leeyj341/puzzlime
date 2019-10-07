using System.Collections;
using System.Collections.Generic;

public class MonsterStatus
{
    private MONSTER_STATUS status = MONSTER_STATUS.FINDING;
    private MONSTER_TYPE type = MONSTER_TYPE.NONE;

    private float hp = 0.0f;
    private float atk = 0.0f;
    private float additionalHp = 1.0f;
    private float additionalAtk = 1.0f;

    private float recognizedRange = 0.0f;

    private Area myArea = null;

    public MONSTER_STATUS CurStatus { get => status; set => status = value; }
    public MONSTER_TYPE Type { get => type; set => type = value; }

    public float Hp { get => hp; set => hp = value; }
    public float Atk { get => atk; set => atk = value; }
    public float AdditionalHp { get => additionalHp; set => additionalHp = value; }
    public float AdditionalAtk { get => additionalAtk; set => additionalAtk = value; }

    public float RecognizedRange { get => recognizedRange; set => recognizedRange = value; }

    public Area MyArea { get => myArea; set => myArea = value; }

    public MonsterStatus(MonsterInfo mInfo, Area area)
    {
        type = mInfo.Type;
        hp = mInfo.Hp;
        atk = mInfo.Atk;
        myArea = area;

        recognizedRange = area.GetPatrolRadius();
    }

}
