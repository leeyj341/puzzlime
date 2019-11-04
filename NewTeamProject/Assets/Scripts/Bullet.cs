using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    BULLET_TYPE m_eType;
    
    float m_fDamage;
    float m_fRange;
    Vector3 m_vStart;

    public BULLET_TYPE Type { get => m_eType; set => m_eType = value; }
    public float Range { get => m_fRange; set => m_fRange = value; }

    private void Update()
    {
        if (Vector3.Distance(m_vStart, transform.position) >= m_fRange)
            BulletOff();
    }

    public void Fire(float damage)
    {
        transform.rotation = GameManager.Instance.Inven.transform.rotation;
        m_vStart = transform.position = GameManager.Instance.Inven.transform.position + 
            GameManager.Instance.Inven.gameObject.transform.forward * 3 + Vector3.up * 2;

        m_fDamage = damage;
        Vector3 temp = (transform.position - GameManager.Instance.Inven.transform.position);
        temp.y = 0;
        GetComponent<Rigidbody>().AddForce(transform.forward * 3, ForceMode.Impulse);
    }

    public void FireArrow(float damage, Transform monsterTransform)
    {
        m_vStart = transform.position = monsterTransform.position + Vector3.up;
        transform.rotation = monsterTransform.rotation;
        m_fDamage = damage;
        GetComponent<Rigidbody>().AddForce(transform.forward * 6, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.name.Equals("CowBoy") &&
            !collision.transform.name.Equals("CowGirl"))
        {
            BulletOff();
        }
    }

    public void BulletOff()
    {
        gameObject.SetActive(false);
        GetComponent<Rigidbody>().Sleep();
    }
}
