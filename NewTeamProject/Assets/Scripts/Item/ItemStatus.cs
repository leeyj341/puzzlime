using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatus : MonoBehaviour
{
    Rigidbody m_sRb;
    SphereCollider m_sCollider;

    public ItemData m_Data;
    private int m_nDbl = 0;
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

    public bool UseItem(ItemStatus SubWeapon)
    {
        if (m_Data.ItemCtg != ITEM_CATEGORY.USE) return false;

        switch(m_Data.ItemNumber)
        {
            case 91://체력회복

                break;
            case 92://속도향상
                BuffManager.Instance.AddBuff(m_Data.MaxDbl, BUFF_CATEGORY.SPEED);   // 버프, 파워도 전달
                break;
            case 93://공격향상
                BuffManager.Instance.AddBuff(m_Data.MaxDbl, BUFF_CATEGORY.ATTACK);
                break;
            case 94://만능총알
                if (!SubWeapon) return false;

                SubWeapon.Dbl += (int)(SubWeapon.m_Data.MaxDbl * m_Data.ItemPower);
                if (SubWeapon.Dbl > SubWeapon.m_Data.MaxDbl) SubWeapon.Dbl = SubWeapon.m_Data.MaxDbl;

                break;
        }

        return true;
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
