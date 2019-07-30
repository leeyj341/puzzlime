using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class PlayerState : MonoBehaviour
{
    [XmlElement("Hp")]
    public float Hp = 10.0f;                                               // 체력
    [XmlElement("MaxHp")]
    public float MaxHp = 10.0f;                                            // 최대 체력
    [XmlElement("Speed")]
    public float Speed = 0.0f;                                             // 이동속도
    [XmlElement("RotSpeed")]
    public float RotSpeed = 240.0f;                                        // 회전속도
    [XmlElement("Atk")]
    public float Atk = 0.0f;                                               // 총 공격력

    [XmlElement("WeaponCategory")]
    public ATK_CATEGORY WeaponCategory = ATK_CATEGORY.NONE;                // 현재 무기 종류
    [XmlElement("AtkSpeed")]
    public float AtkSpeed = 1.0f;                                          // 공격속도

    [XmlElement("Tag")]
    public string Tag = "";                                                // 현재플레이어 태그
    [XmlElement("DefaultWeaponNum")]
    public int DefaultWeaponNum = 0;                                       // 기본 무기

    [XmlElement("Stage")]
    public int Stage = 1;                                                  // 현재 스테이지
    [XmlElement("Gold")]
    public int Gold = 0;                                                   // 소지 현금
   
}
