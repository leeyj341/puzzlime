using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private Vector3 position = Vector3.zero;
    private List<Transform> listPortal = new List<Transform>();
    private bool monsterExit = false;
    private float patrolRange = 0.0f;

    public Vector3 Position { get => position; }
    public List<Transform> ListPortal { get => listPortal; }
    public bool MonsterExit { get => monsterExit; }
    public float PatrolRange { get => patrolRange; }

    void Awake()
    {
        position = transform.position;
        patrolRange = GetComponent<BoxCollider>().size.x / 4.0f;       // 임시
        listPortal.AddRange(GetComponentsInChildren<Transform>());
        monsterExit = false;

        MonsterSpawner.Instance.AddArea(gameObject.name, this);
    }

    // 구역 범위 체크
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Monster"))
            monsterExit = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Monster"))
            monsterExit = true;
    }   
}
