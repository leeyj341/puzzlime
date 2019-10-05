﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    Quaternion direction = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * 6.0f * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * 6.0f * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(transform.up, -150.0f * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(transform.up, 150.0f * Time.deltaTime);
    }
}
