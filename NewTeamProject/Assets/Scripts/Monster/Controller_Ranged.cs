using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Ranged : EnemyController
{
    // Start is called before the first frame update
    private new void Start()
    {
        base.Start();
        StartCoroutine(Motion_Patrol());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Weapon"))
        {
            ChangeCoroutine(Motion_Damaged());
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
                ChangeCoroutine(Motion_Attack());
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
                ChangeCoroutine(Motion_Attack());
        }

        ChangeCoroutine(Motion_Idle());
    }

    protected override IEnumerator Motion_Attack()
    {
        agent.isStopped = true;
       
        aniController.UpdateAnimatorParameter(MONSTER_STATUS.ATTACK);

        // 화살 발사..

        yield return new WaitUntil(() => aniController.IsAnimationEnd());

        if (FindPlayer())
            ChangeCoroutine(Motion_Attack());
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

        if (FindPlayer())
            ChangeCoroutine(Motion_Attack());
        else
            ChangeCoroutine(Motion_Patrol());
    }

    void Fire()
    {
        BulletContainer.Instance.FireArrow(transform);
    }
}
