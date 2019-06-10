using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private float hp = 10.0f;                                               // 체력
    private float maxHp = 10.0f;                                            // 최대 체력
    private float speed = 0.0f;                                             // 이동속도
    private float rotSpeed = 240.0f;                                         // 회전속도
    private float atk = 0.0f;                                               // 총 공격력
    private float additionalAtk = 0.0f;                                     // 추가 공격력

    private ATK_CATEGORY weaponCategory = ATK_CATEGORY.STAB;                // 현재 무기 종류
    private float atkSpeed = 1.0f;                                          // 공격속도

    // 애니메이션 관련 변수

    private ANIM_SORT curAni = ANIM_SORT.BASIC;
    private float animPlaySpeed = 1.0f;                                     // 최종 애니메이션 재생속도
    private float slashSpeed = 3.0f;
    private float stabSpeed = 1.0f;

    // get, set 
    public float Hp { get => hp; set => hp = value; }
    public float MaxHp { get => maxHp; set => maxHp = value; }
    public float Speed { get => speed; set => speed = value; }
    public float RotSpeed { get => rotSpeed; set => rotSpeed = value; }
    public float Atk { get => atk; set => atk = value; }
    public float AdditionalAtk { get => additionalAtk; set => additionalAtk = value; }

    public ATK_CATEGORY WeaponCategory { get => weaponCategory; set => weaponCategory = value; }
    public float AtkSpeed { get => atkSpeed; set => atkSpeed = value; }

    public ANIM_SORT CurAni { get => curAni; set => curAni = value; }
    public float AnimPlaySpeed { get => animPlaySpeed; set => animPlaySpeed = value; }
    public float SlashSpeed { get => slashSpeed; set => slashSpeed = value; }
    public float StabSpeed { get => stabSpeed; set => stabSpeed = value; }
}
