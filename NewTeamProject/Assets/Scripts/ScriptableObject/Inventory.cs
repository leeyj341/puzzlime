using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int m_nCurWeapon = 0;
    int m_nCurUse = 0;
    int m_nCurEquip = 0;
    INVEN_MODE m_eMode = INVEN_MODE.WEAPON;

    Queue<ItemStatus> m_QueueEmptyItem = new Queue<ItemStatus>();
    List<ItemStatus> m_listUseItem = new List<ItemStatus>();
    List<ItemStatus> m_listWeaponItem = new List<ItemStatus>();
    ItemStatus m_sSubWeapon = null;
    public WeaponList m_sList;

    public ItemStatus SubWeapon { get => m_sSubWeapon; set => m_sSubWeapon = value; }
    public int CursorWeapon { get => m_nCurWeapon; set => m_nCurWeapon = value; }
    public int CursorUse { get => m_nCurUse; set => m_nCurUse = value; }

    // Start is called before the first frame update
    private void Start()
    {
        FirstSetting();
    }

    // Update is called once per frame
    void Update()
    {
        KeyAction();
    }

    void FirstSetting()
    {
        m_sList.InitForArr();

        InGameUIManager.Instance.ChangeCursor(m_eMode);

        MakeNewItemStatus();

        AddFirst();
    }

    void AddFirst()
    {
        AddItem(ItemManager.Instance.DictData(11));
        AddItem(ItemManager.Instance.DictData(22));
        AddItem(ItemManager.Instance.DictData(23));
        Equip(m_listWeaponItem[0]);
    }

    void MakeNewItemStatus()
    {
        for(int i = 0; i < 10; i++)
            m_QueueEmptyItem.Enqueue(new ItemStatus());
    }

    public bool AddItem(ItemData item)
    {   
        if(item.ItemCtg == ITEM_CATEGORY.WEAPON)
        {
            //보조무기면
            if (item.AtkCtg == ATK_CATEGORY.SHOT)
            {
                m_QueueEmptyItem.Peek().m_Data = item;
                m_QueueEmptyItem.Peek().Dbl = item.MaxDbl;
                m_sSubWeapon = m_QueueEmptyItem.Dequeue();
                InGameUIManager.Instance.AddImg(m_eMode, m_sSubWeapon.m_Data.Name);
            }
            //주무기면
            else
            {
                if (m_listWeaponItem.Count >= 5) return false;
                m_QueueEmptyItem.Peek().m_Data = item;
                m_QueueEmptyItem.Peek().Dbl = item.MaxDbl;
                m_listWeaponItem.Add(m_QueueEmptyItem.Dequeue());
                InGameUIManager.Instance.AddImg(m_eMode, item.Name);
            }
        }

        else if(item.ItemCtg == ITEM_CATEGORY.USE)
        {
            if (m_listUseItem.Count >= 3) return false;
            m_QueueEmptyItem.Peek().m_Data = item;
            m_QueueEmptyItem.Peek().Dbl = item.MaxDbl;
            m_listUseItem.Add(m_QueueEmptyItem.Dequeue());
        }

        return true;
    }

    public void Equip(ItemStatus item)
    {
        m_sList.ChangeWeapon(item.m_Data.Name);
        SendData(item);
    }

    void SendData(ItemStatus item)
    {
        GameManager.Instance.PS.AdditionalAtk = item.m_Data.ItemPower;
        GameManager.Instance.PS.AtkSpeed = item.m_Data.ItemSpd;
        GameManager.Instance.PS.WeaponCategory = item.m_Data.AtkCtg;
    }

    public void AttackSub()
    {
        if (!m_sSubWeapon) return;

        m_sSubWeapon.Dbl -= 1;

        if(m_sSubWeapon.Dbl == 0)
        {
            m_QueueEmptyItem.Enqueue(m_sSubWeapon);
            m_sSubWeapon = null;
        }
    }

    public void Attack()
    {
        m_listWeaponItem[m_nCurEquip].Dbl -= 1;

        if(m_listWeaponItem[m_nCurEquip].Dbl == 0)
        {
            m_QueueEmptyItem.Enqueue(m_listWeaponItem[m_nCurEquip]);
            m_listWeaponItem.RemoveAt(m_nCurEquip);
            m_nCurEquip--;
            Equip(m_listWeaponItem[m_nCurEquip]);
        }
    }

    public void Use()
    {
        if (!m_listUseItem[m_nCurUse].UseItem(m_sSubWeapon))
            return;

        m_QueueEmptyItem.Enqueue(m_listUseItem[m_nCurUse]);
        m_listUseItem.RemoveAt(m_nCurUse);
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

            m_QueueEmptyItem.Enqueue(m_listWeaponItem[m_nCurWeapon]);
            m_listWeaponItem.RemoveAt(m_nCurWeapon);

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
                m_QueueEmptyItem.Enqueue(m_listUseItem[m_nCurUse]);
                m_listUseItem.RemoveAt(m_nCurUse);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(m_nCurUse < m_listUseItem.Count)
                Use();
        }
    }
}
