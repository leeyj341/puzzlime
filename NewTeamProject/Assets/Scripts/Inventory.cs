using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int m_nCurWeapon = 0;
    int m_nCurUse = 0;
    int m_nCurEquip = 0;
    INVEN_MODE m_eMode;

    List<ItemStatus> m_listUseItem = new List<ItemStatus>();
    public List<ItemStatus> m_listWeaponItem = new List<ItemStatus>();

    private WeaponList m_sWeaponList = null;
    ItemStatus m_sSubWeapon = null;

    public WeaponList WL { get => m_sWeaponList; set => m_sWeaponList = value; }
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
        //가방에 공간이 없다면
        if (m_listWeaponItem.Count >= 5)
            return false;

        //무기인데
        if (item.ItemCtg == ITEM_CATEGORY.WEAPON)
        {
            //보조무기면
            if(item.ItemNubmer / 10 == 4)
            {
                //근데 보조무기를 이미 갖고있다면
                if (m_sSubWeapon) return false;
                //보조무기가 없다면
                else
                {
                    m_sSubWeapon = item;
                    return true;
                }
            }
            //주무기면
            else
            {
                m_listWeaponItem.Add(item);
                return true;
            }
        }
        //소모품이면
        else if(item.ItemCtg == ITEM_CATEGORY.USE)
        {
            //가방에 공간이 있다면
            if (m_listUseItem.Count < 3)
            {
                m_listUseItem.Add(item);
                return true;
            }
        }
        return false;
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
        GameManager.Instance.PS.AdditionalAtk = m_listWeaponItem[m_nCurWeapon].WS.Atk;
        GameManager.Instance.PS.AtkSpeed = m_listWeaponItem[m_nCurWeapon].WS.Spd;
        GameManager.Instance.PS.WeaponCategory = m_listWeaponItem[m_nCurWeapon].WS.AtkCtg;
        
        m_nCurEquip = m_nCurWeapon;

        WL.ChangeWeapon(m_listWeaponItem[m_nCurEquip].ItemName);
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
            if (m_listWeaponItem[m_nCurEquip].WS.Dbl == -1) return;
            
            m_listWeaponItem.Remove(m_listWeaponItem[m_nCurWeapon]);

            if (m_nCurEquip == m_nCurWeapon)
            {
                m_nCurWeapon--;
                Equip();
            }

            else if (m_nCurEquip > m_nCurWeapon)
                m_nCurEquip--;
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
            if(m_listUseItem[m_nCurUse].US.ActiveItem(m_sSubWeapon))
            {
                m_listUseItem.Remove(m_listUseItem[m_nCurUse]);
                m_nCurUse--;
            }
        }
    }
    
}
