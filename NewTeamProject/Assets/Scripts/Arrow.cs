using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float damage;
    private float range;
    Vector3 startPos;

    public float Range { get => range; set => range = value; }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(startPos, transform.position) >= range)
            ArrowOff();
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;

        if (tag.Equals("Ground") || tag.Equals("Obstacle"))
            ArrowOff();
        else if(tag.Equals("Player"))
        {
            //대미지 준다..
            ArrowOff();
        }
    }

    private void ArrowOff()
    {
        gameObject.SetActive(false);
        GetComponent<Rigidbody>().Sleep();
    }

    public void FireArrow(float _damage, Transform monsterTransform)
    {
        startPos = transform.position = monsterTransform.position + Vector3.up;
        transform.rotation = monsterTransform.rotation;
        damage = _damage;
        GetComponent<Rigidbody>().AddForce(transform.forward * 50.0f, ForceMode.Impulse);
    }
}
