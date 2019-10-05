using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform goal = null;
    private Vector3 backPosition = Vector3.zero;
    private NavMeshAgent agent = null;
    private Area myArea = null;

    private IEnumerator coroutineChange = null;

    private MONSTER_STATUS currentStatus = MONSTER_STATUS.FIND;

    public Area Area { get => myArea; set => myArea = value; }

    // Start is called before the first frame update
    void Awake()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        switch (currentStatus)
        {
            case MONSTER_STATUS.FIND:
                Motion_Find();
                break;
            case MONSTER_STATUS.MOVE:
                break;
            case MONSTER_STATUS.FOLLOW:
                Motion_Follow();
                break;
            case MONSTER_STATUS.FOLLOW_BACK:
                Motion_Follow_Back();
                break;
            case MONSTER_STATUS.ATTACK:
                break;
            case MONSTER_STATUS.END:
                break;
        }
    }

    void Init()
    {
        goal = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        //coroutineChange = ChangeMotion(currentStatus);
        //StartCoroutine(coroutineChange);
    }

    void Motion_Find()
    {
        // 플레이어를 찾았으면
        if (Vector3.Distance(goal.position, transform.position) <= myArea.MoveDistance)
        {
            currentStatus = MONSTER_STATUS.FOLLOW;
        }
        else
        {
            currentStatus = MONSTER_STATUS.FIND;
        }
    }

    void Motion_Move()
    {

    }

    void Motion_Follow()
    {
        if(Vector3.Distance(myArea.Position, transform.position) > myArea.LimitedDistance)
        {
            backPosition = RandomPosition(myArea.name);
            currentStatus = MONSTER_STATUS.FOLLOW_BACK;
        }
        else
        {
            agent.SetDestination(goal.position);
        }
    }

    void Motion_Follow_Back()
    {
        if (Vector3.Distance(myArea.Position, transform.position) <= myArea.MoveDistance)
        {
            currentStatus = MONSTER_STATUS.FIND;
        }
        else
        {
            // 계속 돌아가라라라ㅏ라
            agent.SetDestination(backPosition);
        }
    }

    void Motion_Attack()
    {

    }

    Vector3 RandomPosition(string areaName)
    {
        float posX = myArea.Position.x;
        float posZ = myArea.Position.z;
        float distance = myArea.MoveDistance;

        float randomX = Random.Range(posX - distance, posX + distance);
        float randomZ = Random.Range(posZ - distance, posZ + distance);

        return new Vector3(randomX, 0.0f, randomZ);
    }
}
