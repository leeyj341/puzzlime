using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Melee : EnemyController
{
    private new void Start()
    {
        base.Start();
        StartCoroutine(Motion_Patrol());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Weapon"))
        {
            ChangeCoroutine(Motion_Chase());
        }
    }

    protected override IEnumerator Motion_Idle()
    {
        agent.isStopped = true;
        prevPos = transform.position;

        aniController.UpdateAnimatorParameter(MONSTER_STATUS.IDLE);

        float fTime = 0.0f;

        while (fTime < 3.0f)
        {
            yield return null;
            fTime += Time.deltaTime;

            if (FindPlayer())
                ChangeCoroutine(Motion_Chase());
        }

        ChangeCoroutine(Motion_Patrol());
    }

    protected override IEnumerator Motion_Patrol()
    {
        goal = RandomPosition(transform.position);
        agent.SetDestination(goal);
        agent.isStopped = false;

        aniController.UpdateAnimatorParameter(MONSTER_STATUS.PATROL);

        while (!InDistance(transform.position, agent.destination, 0.5f))
        {
            // 무작위 좌표로 이동
            yield return null;

            if (FindPlayer())
                ChangeCoroutine(Motion_Chase());
        }

        ChangeCoroutine(Motion_Idle());
    }

    protected override IEnumerator Motion_Chase()
    {
        agent.SetDestination(GameManager.Instance.PlayerTransfrom.position);
        agent.isStopped = false;

        aniController.UpdateAnimatorParameter(MONSTER_STATUS.CHASE);

        while (FindPlayer())          // 1. 인식 범위 내 && 2. 이동 범위 내 
        {
            yield return null;
            agent.SetDestination(GameManager.Instance.PlayerTransfrom.position);

            if (IsPlayerInAttackRange())                       // 공격 범위 안에 들어온 경우 공격    
                ChangeCoroutine(Motion_Attack());
        }

        // 인식 범위 나간 경우 다시 순찰
        ChangeCoroutine(Motion_Patrol());
    }

    protected override IEnumerator Motion_Attack()
    {
        agent.isStopped = true;

        aniController.UpdateAnimatorParameter(MONSTER_STATUS.ATTACK);

        yield return new WaitUntil(() => aniController.IsAnimationEnd());

        if (IsPlayerInAttackRange())
            ChangeCoroutine(Motion_Attack());

        else if (FindPlayer())
            ChangeCoroutine(Motion_Chase());

        else
            ChangeCoroutine(Motion_Patrol());
    }

    protected override IEnumerator Motion_Damaged()
    {
        agent.isStopped = true;

        aniController.UpdateAnimatorParameter(MONSTER_STATUS.DAMAGED);

        yield return new WaitUntil(() => aniController.IsAnimationEnd());

        if (status.Hp <= 0)
            ChangeCoroutine(Motion_Dead());

        if (IsPlayerInAttackRange())
            ChangeCoroutine(Motion_Attack());

        else if (FindPlayer())
            ChangeCoroutine(Motion_Chase());

        else
            ChangeCoroutine(Motion_Patrol());
    }
}
