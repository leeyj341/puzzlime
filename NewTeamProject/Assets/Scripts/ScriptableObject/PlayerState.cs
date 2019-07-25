using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "PlayerState", menuName = "Data/PlayerData", order = 0)]
public class PlayerState : ScriptableObject
{
    public float Hp = 10.0f;                                               // 체력
    public float MaxHp = 10.0f;                                            // 최대 체력
    public float Speed = 0.0f;                                             // 이동속도
    public float RotSpeed = 240.0f;                                         // 회전속도
    public float Atk = 0.0f;                                               // 총 공격력
    public float AdditionalAtk = 0.0f;                                     // 추가 공격력

    public ATK_CATEGORY WeaponCategory = ATK_CATEGORY.HACK;                // 현재 무기 종류
    public float AtkSpeed = 1.0f;                                          // 공격속도

    // 애니메이션 관련 변수

    public ANIM_SORT CurAni = ANIM_SORT.BASIC;
    public float AnimPlaySpeed = 1.0f;                                     // 최종 애니메이션 재생속도
    public float SlashSpeed = 3.0f;
    public float StabSpeed = 1.0f;
}
