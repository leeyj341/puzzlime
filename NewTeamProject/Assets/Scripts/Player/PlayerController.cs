using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerState State;
    private float h = 0.0f;
    private float v = 0.0f;
    private float RotSpeed = 100.0f;

    private Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        State = gameObject.GetComponent<PlayerState>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetKeyInput();
        Move();
        ChangeAnimation();
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

    private void ChangeAnimation()
    {
        if (v == 0) Anim.SetInteger("Num", 0);
        else
            Anim.SetInteger("Num", 1);
    }
}
