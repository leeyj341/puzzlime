using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private float hp = 10.0f;               // 체력
    private float speed = 10.0f;            // 이동속도
    private float rotSpeed = 80.0f;         // 회전속도
    private float atk = 0.0f;               // 총 공격력
    private float additionalAtk = 0.0f;     // 추가 공격력

    private int weaponNum = 0;              // 현재 무기 종류
    private float atkSpeed = 3.0f;          // 공격속도

    // get, set 
    public float Hp { get => hp; set => hp = value; }
    public float Speed { get => speed; set => speed = value; }
    public float RotSpeed { get => rotSpeed; set => rotSpeed = value; }
    public float Atk { get => atk; set => atk = value; }
    public float AdditionalAtk { get => additionalAtk; set => additionalAtk = value; }

    public int WeaponNum { get => weaponNum; set => weaponNum = value; }
    public float AtkSpeed { get => atkSpeed; set => atkSpeed = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
