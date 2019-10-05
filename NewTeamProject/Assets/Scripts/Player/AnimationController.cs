using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // 애니메이션 관련 변수
    private float animPlaySpeed = 1.0f;                                     // 최종 애니메이션 재생속도
    private float slashSpeed = 3.0f;
    private float stabSpeed = 1.0f;

    private Animator playerAnimator;

    void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void UpdateSpeed(float speed)
    {
        playerAnimator.SetFloat("Speed", speed);
    }

    public void UpdateAnimationParameter()
    {
        if ((int)GameManager.Instance.PS.WeaponCategory < 2)
        {
            animPlaySpeed = GameManager.Instance.PS.AtkSpeed * slashSpeed;
        }
        else if (((int)GameManager.Instance.PS.WeaponCategory).Equals(2))
        {
            animPlaySpeed = GameManager.Instance.PS.AtkSpeed * stabSpeed;
        }

        playerAnimator.SetFloat("AtkAnimPlaySpeed", animPlaySpeed);
    }

    public int GetCurAniNum()
    {
        return playerAnimator.GetInteger("AniNum");
    }

    public void ChangeAniSort(ANIM_SORT eAnimSort)
    {
        playerAnimator.SetInteger("AniNum", (int)eAnimSort);
        playerAnimator.SetInteger("WeaponNum", (int)GameManager.Instance.PS.WeaponCategory);
    }


}
