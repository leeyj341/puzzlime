using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // 애니메이션 관련 변수
    private ANIM_SORT curAni = ANIM_SORT.BASIC;
    private float AnimPlaySpeed = 1.0f;                                     // 최종 애니메이션 재생속도
    private float SlashSpeed = 3.0f;
    private float StabSpeed = 1.0f;

    private Animator PlayerAnimator;

    public ANIM_SORT CurAni { get => curAni; set => curAni = value; }

    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationParameter();
    }

    private void UpdateAnimationParameter()
    {
        if ((int)GameManager.Instance.PS.WeaponCategory < 2)
        {
            AnimPlaySpeed = GameManager.Instance.PS.AtkSpeed * SlashSpeed;
        }
        else if (((int)GameManager.Instance.PS.WeaponCategory).Equals(2))
        {
            AnimPlaySpeed = GameManager.Instance.PS.AtkSpeed * StabSpeed;
        }

        PlayerAnimator.SetFloat("AtkAnimPlaySpeed", AnimPlaySpeed);
        PlayerAnimator.SetFloat("Speed", GameManager.Instance.PS.Speed);   
    }

    public void ChangeAniSort(ANIM_SORT eAnimSort)
    {
        curAni = eAnimSort;
        PlayerAnimator.SetInteger("AniNum", (int)curAni);
        PlayerAnimator.SetInteger("WeaponNum", (int)GameManager.Instance.PS.WeaponCategory);
    }


}
