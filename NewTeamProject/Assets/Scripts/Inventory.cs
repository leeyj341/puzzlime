using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int m_nCurWeapon = 0;
    int m_nCurUse = 0;
    int m_nCurEquip = 0;
    INVEN_MODE m_eMode;
    ATK_CATEGORY m_eCurWATK = ATK_CATEGORY.HACK;

    List<ItemStatus> m_listUseItem = new List<ItemStatus>();
    List<ItemStatus> m_listWeaponItem = new List<ItemStatus>();

    ItemStatus m_sSubWeapon = null;

    public ItemStatus SubWeapon { get => m_sSubWeapon; set => m_sSubWeapon = value; } 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        KeyAction();
    }

    public void Consum()
    {
        if(!m_listWeaponItem[m_nCurEquip].WS.Consum())
        {
            m_listWeaponItem.Remove(m_listWeaponItem[m_nCurEquip]);
            if (m_nCurWeapon == m_listWeaponItem.Count) m_nCurWeapon--;
            Equip();
        }
    }

    public bool AddItem(ItemStatus item)
    {
        bool Added = false;

        if (item.IsWeapon)
        {
            if(m_listWeaponItem.Count < 5)
            {
                m_listWeaponItem.Add(item);
                m_nCurWeapon++;
                Added = true;
            }
        }

        else if(!item.IsWeapon)
        {
            if (m_listUseItem.Count < 3)
            {
                m_listUseItem.Add(item);
                m_nCurUse++;
                Added = true;
            }
        }
        if (Added)
            item.GetComponent<Transform>().gameObject.SetActive(false);

        return Added;
    }

    public void ItemUse()
    {
        if (!m_listWeaponItem[m_nCurWeapon].WS.Consum())
            m_listWeaponItem.Remove(m_listWeaponItem[m_nCurWeapon]);
    }

    void KeyAction()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            m_eMode = INVEN_MODE.WEAPON;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            m_eMode = INVEN_MODE.USE;

        if (m_eMode == INVEN_MODE.WEAPON)
            KeyAction_WEAPON_MODE();
        else if (m_eMode == INVEN_MODE.USE)
            KeyAction_USE_MODE();
    }

    void Equip()
    {
        transform.GetComponent<PlayerState>().AdditionalAtk = m_listWeaponItem[m_nCurWeapon].WS.Atk;
        m_eCurWATK = m_listWeaponItem[m_nCurWeapon].WS.AtkCtg;

        //공격속도 추가


        m_nCurEquip = m_nCurWeapon;

        ChangeWeapon();
    }

    void KeyAction_WEAPON_MODE()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (m_nCurWeapon > 0 )
                m_nCurWeapon--;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            if (m_nCurWeapon + 1 < m_listWeaponItem.Count)
                m_nCurWeapon++;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (m_listWeaponItem.Count > 0)
            {
                if (m_nCurEquip == m_nCurWeapon)
                {
                    m_nCurEquip--;
                    Equip();
                }
                m_listWeaponItem.Remove(m_listWeaponItem[m_nCurWeapon]);
                m_nCurWeapon--;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Equip();

        }
    }

    void KeyAction_USE_MODE()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (m_nCurUse > 0)
                m_nCurUse--;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (m_nCurUse + 1 < m_listUseItem.Count)
                m_nCurUse++;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (m_listUseItem.Count > 0)
            {
                m_listUseItem.Remove(m_listUseItem[m_nCurUse]);
                m_nCurUse--;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_listUseItem[m_nCurUse].US.ActiveItem(m_sSubWeapon);
            m_nCurUse--;
        }
    }

    public void ChangeWeapon()
    {
        WeaponList[] temp = GetComponentsInChildren<WeaponList>();
        foreach (WeaponList t in temp)
        {
            if (t.transform.Find("피스톨"))
                t.InactiveWeapon("피스톨");

            if (t.transform.Find("질 낮은 칼"))
                t.ActiveWeapon("질 낮은 칼");
        }
    }

    public void ChangeSubWeapon()
    {
        WeaponList[] temp = GetComponentsInChildren<WeaponList>();
        foreach (WeaponList t in temp)
        {
            if (t.transform.Find("질 낮은 칼"))
                t.InactiveWeapon("질 낮은 칼");

            if (t.transform.Find("피스톨"))
                t.ActiveWeapon("피스톨");
        }
    }
}
