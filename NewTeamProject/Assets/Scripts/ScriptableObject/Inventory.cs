using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int m_nCurWeapon = 0;
    int m_nCurUse = 0;
    int m_nCurEquip = 0;
    INVEN_MODE m_eMode;

    List<ItemStatus> m_listUseItem = new List<ItemStatus>(3);
    List<ItemStatus> m_listWeaponItem = new List<ItemStatus>(5);
    ItemStatus m_sSubWeapon = null;
    
    public ItemStatus SubWeapon { get => m_sSubWeapon; set => m_sSubWeapon = value; } 
    public int CursorWeapon { get => m_nCurWeapon; set => m_nCurWeapon = value; }
    public int CursorUse { get => m_nCurUse; set => m_nCurUse = value; }
    // Start is called before the first frame update
    void Start()
    {
        m_eMode = INVEN_MODE.WEAPON;
        InGameUIManager.Instance.ChangeCursor(m_eMode);

        GameManager.Instance.WL = GameObject.Find("RightWeapon").GetComponent<WeaponList>();
        GameManager.Instance.WL.InitForArr();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        KeyAction();
    }

    public bool AddWeapon(ItemStatus item)
    {
        //가방에 공간이 없다면
        if (m_listWeaponItem.Count >= 5 || m_sSubWeapon)
            return false;
        
        //보조무기면
        if (item.Data.AtkCtg == ATK_CATEGORY.SHOT)
        {
            m_sSubWeapon = item;
            InGameUIManager.Instance.AddWeaponImg(true, m_sSubWeapon.Data.Name);
        }
        //주무기면
        else
        {
            m_listWeaponItem.Add(item);
            InGameUIManager.Instance.AddWeaponImg(false, item.Data.Name);
        }            

        return true;
    }

    public bool AddUseItem(ItemStatus item)
    {
        if (m_listUseItem.Count >= 3)
            return false;

        m_listUseItem.Add(item);
        return true;
    }

    public void Equip(ItemStatus item)
    {
        if(!item) return;
        GameManager.Instance.WL.ChangeWeapon(item.Data.Name);
        SendData(item);
    }

    void SendData(ItemStatus item)
    {
        GameManager.Instance.PS.AdditionalAtk = item.Data.ItemPower;
        GameManager.Instance.PS.AtkSpeed = item.Data.ItemSpd;
        GameManager.Instance.PS.WeaponCategory = item.Data.AtkCtg;
    }

    public void AttackSub()
    {
        if (m_sSubWeapon.Dbl == 0) return;

        m_sSubWeapon.Dbl -= 1;
    }

    public void Attack()
    {
        if (m_listWeaponItem[m_nCurEquip].Dbl == 0) return;

        m_listWeaponItem[m_nCurEquip].Dbl -= 1;

        if(m_listWeaponItem[m_nCurEquip].Dbl == 0)
        {
            m_nCurEquip--;

            Equip(m_listWeaponItem[m_nCurEquip]);
        }
    }

    public void Use()
    {
        if (m_listUseItem[m_nCurUse].Dbl == 0) return;

        m_listUseItem[m_nCurUse].Dbl--;
    }

    void KeyAction()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_eMode = INVEN_MODE.WEAPON;
            InGameUIManager.Instance.ChangeCursor(m_eMode);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_eMode = INVEN_MODE.USE;
            InGameUIManager.Instance.ChangeCursor(m_eMode);
        }

        if (m_eMode == INVEN_MODE.WEAPON)
            KeyAction_WEAPON_MODE();
        else if (m_eMode == INVEN_MODE.USE)
            KeyAction_USE_MODE();
    }
    

    void KeyAction_WEAPON_MODE()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_nCurWeapon -= 1;
            if (m_nCurWeapon < 0)
                m_nCurWeapon = 4;
            InGameUIManager.Instance.MoveCursor(m_eMode, m_nCurWeapon);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_nCurWeapon += 1;
            if (m_nCurWeapon + 1 > 5)               //여기
                m_nCurWeapon = 0;
            InGameUIManager.Instance.MoveCursor(m_eMode, m_nCurWeapon);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (m_listWeaponItem.Count <= m_nCurWeapon) return;

            if (m_listWeaponItem[m_nCurWeapon].Dbl == -1) return;
            
            
            InGameUIManager.Instance.DeleteImage(m_eMode, m_nCurWeapon);

            if (m_nCurEquip >= m_nCurWeapon)
            {
                m_nCurEquip -= 1;
                Equip(m_listWeaponItem[m_nCurEquip]);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (m_nCurWeapon == m_nCurEquip) return;
            if(m_nCurWeapon < m_listWeaponItem.Count)
            {
                m_nCurEquip = m_nCurWeapon;
                Equip(m_listWeaponItem[m_nCurEquip]);
            }
        }
    }

    void KeyAction_USE_MODE()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_nCurUse -= 1;
            if (m_nCurUse < 0)
                m_nCurUse = 2;

            InGameUIManager.Instance.MoveCursor(m_eMode, m_nCurUse);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_nCurUse += 1;
            if (m_nCurUse + 1 > 3)                  //여기
                m_nCurUse = 0;
            InGameUIManager.Instance.MoveCursor(m_eMode, m_nCurUse);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (m_listUseItem.Count > 0)
            {
                m_listUseItem.RemoveAt(m_nCurUse);
                m_nCurUse -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(m_nCurUse < m_listUseItem.Count)
                Use();
        }
    }
}
