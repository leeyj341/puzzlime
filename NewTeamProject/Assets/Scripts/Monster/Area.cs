using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private Vector3 position = Vector3.zero;
    private float limitedDistance = 0.0f;
    private SphereCollider sCollider = null;

    private bool isPlayerEntered = false;

    public Vector3 Position { get => position; set => position = value; }
    public float LimitedDistance { get => limitedDistance; set => limitedDistance = value; }

    public bool IsPlayerEntered { get => isPlayerEntered; }

    void Awake()
    {
        position = transform.position;
        limitedDistance = 30.0f;            // 중점부터 ~ Distance
        sCollider = GetComponent<SphereCollider>();

        MonsterSpawner.Instance.AddArea(gameObject.name, this);
    }

    // 구역 범위 체크
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public float GetRadius()
    {
        return sCollider.radius;
    }
}
