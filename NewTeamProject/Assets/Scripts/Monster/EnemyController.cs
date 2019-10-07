using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{  
    private NavMeshAgent agent = null;
    private EnemyAniController aniController = null;
    
    private Transform goal = null;
    private Vector3 backPosition = Vector3.zero;
    private Coroutine coChangeMotion;

    private MonsterStatus status = null;

    public MonsterStatus Status { get => status; set => status = value; }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        goal = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        aniController = GetComponent<EnemyAniController>();
        aniController.SetAnimatorType(status.Type);

        StartCoroutine("ChangeMotion");
    }

    void UpdateAniParameter()
    {

    }

    IEnumerator ChangeMotion()
    {
        yield return null;

        aniController.UpdateAnimatorParameter(status.CurStatus);
        switch (status.CurStatus)
        {
            case MONSTER_STATUS.FINDING:
                Motion_Find();
                break;
            case MONSTER_STATUS.PATROL:
                break;
            case MONSTER_STATUS.CHASE:
                Motion_Chase();
                break;
            case MONSTER_STATUS.CHASE_BACK:
                Motion_Chase_Back();
                break;
            case MONSTER_STATUS.ATTACK:
                break;
            case MONSTER_STATUS.DAMAGED:
                break;
            case MONSTER_STATUS.DEAD:
                break;
        }
    }

    void Motion_Find()
    {
        // 플레이어를 찾았으면
        if (Vector3.Distance(transform.position, goal.position) <= status.RecognizedRange)
        {
            status.CurStatus = MONSTER_STATUS.CHASE;
        }
        else
        {
            status.CurStatus = MONSTER_STATUS.FINDING;
        }
        StartCoroutine("ChangeMotion");
    }

    void Motion_Move()
    {

    }

    void Motion_Chase()
    {
        if ((Vector3.Distance(status.MyArea.Position, transform.position) > status.MyArea.LimitedDistance)
            || (Vector3.Distance(transform.position, goal.position) > status.RecognizedRange))
        {
            backPosition = RandomPosition(status.MyArea.name);
            status.CurStatus = MONSTER_STATUS.CHASE_BACK;
        }
        else
        {
            agent.SetDestination(goal.position);
        }
        StartCoroutine("ChangeMotion");
    }

    void Motion_Chase_Back()
    {
        if (Vector3.Distance(status.MyArea.Position, transform.position) <= status.RecognizedRange)
        {
            status.CurStatus = MONSTER_STATUS.FINDING;
        }
        else
        {
            // 계속 돌아가라라라ㅏ라
            agent.SetDestination(backPosition);
        }
        StartCoroutine("ChangeMotion");
    }

    void Motion_Attack()
    {

    }

    Vector3 RandomPosition(string areaName)
    {
        float posX = status.MyArea.Position.x;
        float posZ = status.MyArea.Position.z;
        float distance = status.MyArea.GetRadius();

        float randomX = Random.Range(posX - distance, posX + distance);
        float randomZ = Random.Range(posZ - distance, posZ + distance);

        return new Vector3(randomX, 0.0f, randomZ);
    }
}
