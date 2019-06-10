using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private PlayerState State;
    private Animator PlayerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        State = GetComponent<PlayerState>();
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAnimationSpeed();
        ChangeAnimationParameter();
    }

    private void ChangeAnimationSpeed()
    {
        if((int)State.WeaponCategory < 2)
        {
            State.AnimPlaySpeed = State.AtkSpeed * State.SlashSpeed;
        }
        else if((int)State.WeaponCategory == 2)
        {
            State.AnimPlaySpeed = State.AtkSpeed * State.StabSpeed;
        }
    }

    public void ChangeAnimationParameter()
    {
        PlayerAnimator.SetFloat("Speed", State.Speed);
        PlayerAnimator.SetFloat("AtkAnimPlaySpeed", State.AnimPlaySpeed);
        PlayerAnimator.SetInteger("AniNum", (int)State.CurAni);
        PlayerAnimator.SetInteger("WeaponNum", (int)State.WeaponCategory);
    }


}
