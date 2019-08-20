using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    private Transform m_sCurWeapon = null;

    private Transform[] m_ArrTransform = new Transform[15];

    public Transform CurWeapon { get => m_sCurWeapon; set => m_sCurWeapon = value; }

    // Start is called before the first frame update

    // Update is called once per frame

    public void InitForArr()
    {
        GameObject obj = transform.gameObject;
        m_ArrTransform = obj.GetComponentsInChildren<Transform>(true);
    }

    public void ChangeWeapon(string WeaponName)
    {
        if(m_sCurWeapon)
            if (m_sCurWeapon.name.Equals(WeaponName)) return;

        for(int i = 0; i < m_ArrTransform.Length; i++)
        {
            if (m_ArrTransform[i].name.Equals(WeaponName))
            {
                if(m_sCurWeapon)
                    InactiveWeapon(m_sCurWeapon);
                
                m_sCurWeapon = m_ArrTransform[i];
                ActiveWeapon(m_sCurWeapon);
            }
        }
    }

    public void ShotChange()
    {

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
