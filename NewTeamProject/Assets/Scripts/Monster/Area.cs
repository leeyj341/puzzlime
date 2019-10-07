using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private Vector3 position = Vector3.zero;
    private SphereCollider sCollider = null;

    private bool isPlayerEntered = false;

    public Vector3 Position { get => position; }

    public bool IsPlayerEntered { get => isPlayerEntered; }

    void Awake()
    {
        position = transform.position;
        sCollider = GetComponent<SphereCollider>();

        MonsterSpawner.Instance.AddArea(gameObject.name, this);
    }

    // 구역 범위 체크
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            isPlayerEntered = true;
        else
            isPlayerEntered = false;
    }

    public float GetPatrolRadius()
    {
        return sCollider.radius;
    }
}
