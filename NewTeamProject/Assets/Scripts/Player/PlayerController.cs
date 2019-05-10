using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerState State;
    private float h = 0.0f;
    private float v = 0.0f;
    private float RotSpeed = 80.0f;

    // Start is called before the first frame update
    void Start()
    {
        State = gameObject.GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        GetKeyInput();
        Move();
    }

    private void GetKeyInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * State.Speed * v * Time.deltaTime);
        transform.Rotate(Vector3.up * RotSpeed * h * Time.deltaTime);
    }
}
