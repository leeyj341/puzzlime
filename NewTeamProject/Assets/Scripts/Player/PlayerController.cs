using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerState state;
    private CharacterController controller;
    private AnimationController animController;
    private float h = 0.0f;
    private float v = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        state = GameManager.Instance.PS;
        controller = GetComponent<CharacterController>();
        animController = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameTime.Equals(Constants.GameTime)) return;

        KeyInput();         // 키입력 
        Move();             // 움직임

        Die();
    }

    private void KeyInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (v != 0)
        {
            state.Speed = 10.0f;
            animController.UpdateSpeed(state.Speed);
        }
        else
        {
            state.Speed = 0;
            animController.UpdateSpeed(state.Speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //일반 공격
            if (animController.GetCurAniNum().Equals((int)ANIM_SORT.SHOOT)) return;

            animController.UpdateAnimationParameter();
            animController.ChangeAniSort(ANIM_SORT.ATTACK);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // 총 쏘기
            if (GameManager.Instance.Inven.SubWeapon == null) return;
            if (!animController.GetCurAniNum().Equals((int)ANIM_SORT.BASIC)) return;

            animController.ChangeAniSort(ANIM_SORT.SHOOT);
            GameManager.Instance.Inven.AttackSub();
        }
    }

    private void Move()
    {
        transform.Rotate(transform.up * state.RotSpeed * h * Time.deltaTime);
        controller.Move(transform.forward * state.Speed * v * Time.deltaTime);    
    }

    private void Die()
    {
        if (state.Hp <= 0.0f)
        {
            gameObject.SetActive(false);
        }
    }

    public void Fire()
    {
        BulletContainer.Instance.Fire();
        GameManager.Instance.Inven.SubWeaponOff();
    }
}
