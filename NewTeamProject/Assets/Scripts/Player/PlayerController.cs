using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerState State;
    private AnimationController AnimController;
    private CharacterController Controller;
    //private Inventory Iven;

    private float h = 0.0f;
    private float v = 0.0f;

    private float speed = 0.0f;

    private ANIM_BEHAVIOR curBehavior = ANIM_BEHAVIOR.NONE;

    // Start is called before the first frame update
    void Start()
    {
        State = GetComponent<PlayerState>();
        AnimController = GetComponent<AnimationController>();
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();         // 키입력 
        Move();             // 움직임
        ChangeAnimation();  // 애니메이션 변경
    }

    private void KeyInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        curBehavior = ANIM_BEHAVIOR.NONE;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //일반 공격

            curBehavior = ANIM_BEHAVIOR.ATTACK;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //총 쏘기
            curBehavior = ANIM_BEHAVIOR.SHOOT;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //회복 아이템 사용
        }
    }

    private void Move()
    {
        if (v != 0)
        {
            speed = State.Speed;
        }
        else
        {
            speed = 0;
        }

        // 발사 상태일 때 (true, false로 구분해 속도조절)
        //if (AnimController.PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Gunplay")) speed = 0;

        transform.Rotate(transform.up * State.RotSpeed * h * Time.deltaTime);
        Controller.Move(transform.forward * speed * v * Time.deltaTime);    
    }

    private void ChangeAnimation()
    {
        AnimController.ChangeParameter("Speed", speed);

        //AnimController.ChangeParameter("BehaviorNum", (int)curBehavior);
        AnimController.ChangeParameter("WeaponNum", State.WeaponNum);
        AnimController.ChangeParameter("AtkSpeed", State.AtkSpeed);
    }
}
