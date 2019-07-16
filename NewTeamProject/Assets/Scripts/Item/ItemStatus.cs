using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatus : MonoBehaviour
{
    Rigidbody m_sRb;
    SphereCollider m_sCollider;

    ItemData m_Data;
    private int m_nDbl;
    public ItemData Data { get => m_Data; set => m_Data = value; }
    public int Dbl { get => m_nDbl; set => m_nDbl = value; }
   
    private void Start()
    {
        m_sRb = transform.GetComponent<Rigidbody>();
        m_sCollider = transform.GetComponent<SphereCollider>();
    }

    private void Update()
    {
        transform.Rotate(0, 2, 0);
    }

    public void SetItemData(ItemData data)
    {
        m_Data = data;
        m_nDbl = m_Data.MaxDbl;
    }

    public void ActivateItem(bool Active)
    {
        if(Active)
        {
            m_sRb.isKinematic = false;
            m_sRb.useGravity = true;
        }
        else
        {
            m_sRb.isKinematic = true;
            m_sRb.useGravity = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Ground")
        {
            ActivateItem(false);
        }
    }
}
