﻿using System.Collections;
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
        patrolRange = GetComponent<BoxCollider>().size.x * 0.45f;
        listPortal.AddRange(GetComponentsInChildren<Transform>());
        monsterExit = false;

        MonsterSpawner.Instance.AddArea(gameObject.name, this);
    }  
}
