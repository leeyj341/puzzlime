using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    private Transform m_sPrevWeapon = null;
    private Transform m_sCurWeapon = null;

    private Transform[] m_ArrTransform;

    public Transform PrevWeapon { get => m_sPrevWeapon; set => m_sPrevWeapon = value; }
    public Transform CurWeapon { get => m_sCurWeapon; set => m_sCurWeapon = value; }
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = transform.gameObject;
        m_ArrTransform = obj.GetComponentsInChildren<Transform>(true);

        GameManager.Instance.Player.GetComponent<Inventory>().WL = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeWeapon(string WeaponName)
    {
        if (m_sCurWeapon.tag == WeaponName) return;

        foreach (Transform i in m_ArrTransform)
        {
            if (i.tag == WeaponName)
            {
                if(m_sCurWeapon)
                    InactiveWeapon(m_sCurWeapon);
                
                m_sPrevWeapon = m_sCurWeapon;
                m_sCurWeapon = i;
                ActiveWeapon(m_sCurWeapon);
            }
        }
    }

    public void ChangePrev()
    {
        if (!m_sPrevWeapon) return;

        InactiveWeapon(m_sCurWeapon);
        ActiveWeapon(m_sPrevWeapon);
        Transform Temp = m_sCurWeapon;
        m_sCurWeapon = m_sPrevWeapon;
        m_sPrevWeapon = Temp;
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
