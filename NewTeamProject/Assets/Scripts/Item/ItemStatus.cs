using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatus : MonoBehaviour
{
    Rigidbody m_sRb;
    SphereCollider m_sCollider;

    protected short m_nItemNumber;
    protected ITEM_CATEGORY m_eItemCtg;
    protected string m_sName;
    
    public short ItemNumber { get => m_nItemNumber; set => m_nItemNumber = value; }
    public ITEM_CATEGORY ItemCtg { get => m_eItemCtg; set => m_eItemCtg = value; }
    public string ItemName { get => m_sName; set => m_sName = value; }

    private void Start()
    {
        m_sRb = transform.GetComponent<Rigidbody>();
        m_sCollider = transform.GetComponent<SphereCollider>();
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
