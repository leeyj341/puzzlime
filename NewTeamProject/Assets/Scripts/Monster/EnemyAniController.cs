using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAniController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnimatorType(MONSTER_TYPE eType)
    {
        animator.SetInteger("MonsterType", (int)eType);
    }

    public void UpdateAnimatorParameter(MONSTER_STATUS eStatus)
    {
        animator.SetInteger("MonsterStatus", (int)eStatus);
    }

    public bool IsAnimationEnd()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            return true;

        return false;
    }

    public string GetName()
    {
        return animator.GetCurrentAnimatorStateInfo(0).shortNameHash.ToString();
    }
}
