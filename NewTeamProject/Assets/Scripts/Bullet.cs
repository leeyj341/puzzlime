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
    // Start is called before the first frame update
    void Start()
    {
        m_fRange = 50;
    }

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
        transform.GetComponent<Rigidbody>().AddForce(transform.forward * 3, ForceMode.Impulse);
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
        transform.GetComponent<Rigidbody>().Sleep();
    }
}
