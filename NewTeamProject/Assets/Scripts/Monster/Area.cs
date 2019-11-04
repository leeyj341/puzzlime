using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private Vector3 position = Vector3.zero;
    private List<Transform> listPortal = new List<Transform>();
    private float patrolRange = 0.0f;

    public Vector3 Position { get => position; }
    public List<Transform> ListPortal { get => listPortal; }
    public float PatrolRange { get => patrolRange; }

    void Awake()
    {
        position = transform.position;
        patrolRange = GetComponent<BoxCollider>().size.x * 0.45f;
        listPortal.AddRange(GetComponentsInChildren<Transform>());

        MonsterSpawner.Instance.AddArea(gameObject.name, this);
    }  
}
