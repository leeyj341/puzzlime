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
}
