using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public float Hp = 10.0f;                                               // 체력
    public float MaxHp = 10.0f;                                            // 최대 체력
    public float Speed = 0.0f;                                             // 이동속도
    public float RotSpeed = 240.0f;                                        // 회전속도
    public float Atk = 0.0f;                                               // 총 공격력

    public ATK_CATEGORY WeaponCategory = ATK_CATEGORY.NONE;                // 현재 무기 종류
    public float AtkSpeed = 1.0f;                                          // 공격속도

    public string Tag = "";                                                // 현재플레이어 태그
    public int DefaultWeaponNum = 0;                                       // 기본 무기

    public int Stage = 1;                                                  // 현재 스테이지
    public int Gold = 0;                                                   // 소지 현금

    public void Set(SaveInfo si)
    {
        WeaponCategory = (ATK_CATEGORY)si.WeaponCategory;
        Tag = si.Tag;
        DefaultWeaponNum = si.DefaultWeaponNum;
        Stage = si.Stage;
        Gold = si.Gold;
    }

    public void Initialize()
    {
        Hp = 10.0f;
        MaxHp = 10.0f;
        Speed = 0.0f;
        RotSpeed = 240.0f;
        Atk = 0.0f;

        WeaponCategory = ATK_CATEGORY.NONE;
        AtkSpeed = 1.0f;

        Tag = "";
        DefaultWeaponNum = 0;

        Stage = 1;
        Gold = 0;
    }
   
}
