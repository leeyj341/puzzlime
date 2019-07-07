using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int m_nCurWeapon = 0;
    int m_nCurUse = 0;
    int m_nCurEquip = 0;
    INVEN_MODE m_eMode;

    List<UseScript> m_listUseItem = new List<UseScript>();
    List<WeaponScript> m_listWeaponItem = new List<WeaponScript>();
    public WeaponScript m_sSubWeapon = null;
    
    public WeaponScript SubWeapon { get => m_sSubWeapon; set => m_sSubWeapon = value; } 
    public int CursorWeapon { get => m_nCurWeapon; set => m_nCurWeapon = value; }
    public int CursorUse { get => m_nCurUse; set => m_nCurUse = value; }
    // Start is called before the first frame update
    void Start()
    {
        m_eMode = INVEN_MODE.WEAPON;
        InGameUIManager.Instance.ChangeCursor(m_eMode);

        GameManager.Instance.WL = GameObject.Find("RightWeapon").GetComponent<WeaponList>();
        GameManager.Instance.WL.InitForArr();

        AddWeapon(ItemManager.Instance.MakeWeapon(22, ATK_CATEGORY.STAB));
        AddWeapon(ItemManager.Instance.MakeWeapon(12, ATK_CATEGORY.HACK));
        AddWeapon(ItemManager.Instance.MakeWeapon(32, ATK_CATEGORY.HIT));
        AddWeapon(ItemManager.Instance.MakeWeapon(41, ATK_CATEGORY.SHOT));

        Equip(m_listWeaponItem[0]);
    }

    // Update is called once per frame
    void Update()
    {
        KeyAction();
    }

    public bool AddWeapon(WeaponScript item)
    {
        //가방에 공간이 없다면
        if (m_listWeaponItem.Count >= 5 || m_sSubWeapon)
            return false;
        
        //보조무기면
        if (item.AtkCtg == ATK_CATEGORY.SHOT)
        {
            m_sSubWeapon = item;
            InGameUIManager.Instance.AddWeaponImg(true, m_sSubWeapon.ItemName);
        }
        //주무기면
        else
        {
            m_listWeaponItem.Add(item);
            InGameUIManager.Instance.AddWeaponImg(false, item.ItemName);
        }            

        return true;
    }

    public bool AddUseItem(UseScript item)
    {
        if (m_listUseItem.Count >= 3)
            return false;

        m_listUseItem.Add(item);
        return true;
    }

    public void Equip(WeaponScript item)
    {
        GameManager.Instance.WL.ChangeWeapon(item.ItemName);
        SendData(item);
    }

    void SendData(WeaponScript item)
    {
        GameManager.Instance.PS.AdditionalAtk = item.Atk;
        GameManager.Instance.PS.AtkSpeed = item.Spd;
        GameManager.Instance.PS.WeaponCategory = item.AtkCtg;
    }

    public void AttackSub()
    {
        if(ItemManager.Instance.ActiveWeaponItem(m_sSubWeapon))
        {
            m_sSubWeapon = null;
        }
    }

    public void Attack()
    {
        if (ItemManager.Instance.ActiveWeaponItem(m_listWeaponItem[m_nCurEquip]))
        {
            ItemManager.Instance.Queue_Weapon.Enqueue(m_listWeaponItem[m_nCurEquip]);
            m_listWeaponItem.Remove(m_listWeaponItem[m_nCurEquip]);

            m_nCurEquip--;

            Equip(m_listWeaponItem[m_nCurEquip]);
        }
    }

    public void Use()
    {
        if(ItemManager.Instance.ActiveUseItem(m_listUseItem[m_nCurUse]))
        {
            ItemManager.Instance.Queue_Use.Enqueue(m_listUseItem[m_nCurUse]);
            m_listUseItem.RemoveAt(m_nCurUse);
        }
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
            
            ItemManager.Instance.Queue_Weapon.Enqueue(m_listWeaponItem[m_nCurWeapon]);
            m_listWeaponItem.RemoveAt(m_nCurWeapon);
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
                ItemManager.Instance.Queue_Use.Enqueue(m_listUseItem[m_nCurUse]);
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
