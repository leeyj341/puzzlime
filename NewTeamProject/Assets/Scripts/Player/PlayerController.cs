using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerState State;
    private CharacterController Controller;
    //private Inventory Iven;

    private float h = 0.0f;
    private float v = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        State = GetComponent<PlayerState>();
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();         // 키입력 
        Move();             // 움직임
    }

    private void KeyInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (v != 0)
        {
            State.Speed = 10.0f;
        }
        else
        {
            State.Speed = 0;
        }

        State.CurAni = ANIM_SORT.NONE;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //일반 공격
            // State.WeaponCategory = Inven.무엇;
            State.CurAni = ANIM_SORT.ATTACK;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //총 쏘기
            //State.WeaponCategory = Inven.무엇;
            State.CurAni = ANIM_SORT.SHOOT;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //회복 아이템 사용
        }
    }

    private void Move()
    {
        transform.Rotate(transform.up * State.RotSpeed * h * Time.deltaTime);
        Controller.Move(transform.forward * State.Speed * v * Time.deltaTime);    
    }
}
