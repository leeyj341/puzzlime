using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private Vector3 position = Vector3.zero;
    private float moveDistance = 0.0f;
    private float limitedDistance = 0.0f;

    public Vector3 Position { get => position; set => position = value; }
    public float MoveDistance { get => moveDistance; set => moveDistance = value; }
    public float LimitedDistance { get => limitedDistance; set => limitedDistance = value; }

    void Awake()
    {
        position = transform.position;
        moveDistance = 15.0f;
        limitedDistance = 20.0f;

        MonsterSpawner.Instance.AddArea(gameObject.name, this);
    }
}
