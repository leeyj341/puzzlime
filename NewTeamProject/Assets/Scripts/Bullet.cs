using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    float m_fDamage;
    float m_fRange;
    // Start is called before the first frame update
    void Start()
    {
        m_fDamage = 0;
        m_fRange = 0;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire(float Damage, float range)
    {
        m_fDamage = Damage;
        m_fRange = range;
        
        rb.AddForce(new Vector3(0,0,5), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Equals("Ground"))
        {
            gameObject.SetActive(false);
        }
    }
}
