using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    private Transform m_tCurWeapon = null;
    private Transform m_tCurSubWeapon = null;

    private Transform[] m_ArrTransform = new Transform[15];

    public Transform CurWeapon { get => m_tCurWeapon; set => m_tCurWeapon = value; }
    public Transform CurSub { get => m_tCurSubWeapon; set => m_tCurSubWeapon = value; }

    // Start is called before the first frame update

    // Update is called once per frame

    public void InitForArr()
    {
        GameObject obj = transform.gameObject;
        m_ArrTransform = obj.GetComponentsInChildren<Transform>(true);
    }

    public void ChangeWeapon(string WeaponName)
    {
        if(m_tCurWeapon)
            if (m_tCurWeapon.name.Equals(WeaponName)) return;

        for(int i = 0; i < m_ArrTransform.Length; i++)
        {
            if (m_ArrTransform[i].name.Equals(WeaponName))
            {
                if(m_tCurWeapon)
                    InactiveWeapon(m_tCurWeapon);
                
                m_tCurWeapon = m_ArrTransform[i];
                ActiveWeapon(m_tCurWeapon);
            }
        }
    }

    public void ChangeSub(string WeaponName)
    {
        for (int i = 0; i < m_ArrTransform.Length; i++)
        {
            if (m_ArrTransform[i].name.Equals(WeaponName))
            {
                if (m_tCurWeapon)
                    InactiveWeapon(m_tCurWeapon);

                m_tCurSubWeapon = m_ArrTransform[i];
                ActiveWeapon(m_tCurSubWeapon);
            }
        }
    }

    public void ChangeEquip()
    {
        InactiveWeapon(m_tCurSubWeapon);
        ActiveWeapon(m_tCurWeapon);
    }

    void ActiveWeapon(Transform Weapon)
    {
        Weapon.gameObject.SetActive(true);
    }
    void InactiveWeapon(Transform Weapon)
    {
        Weapon.gameObject.SetActive(false);
    }
}
