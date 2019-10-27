using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    private int dbl;
    private ItemData data;

    public int Dbl { set => dbl = value; get => dbl; }
    public ItemData Data { set => data = value; get => data; }

    public InventoryItem Init()
    {
        dbl = 0;
        data = null;
        return this;
    }

    public bool UseItem(InventoryItem Subweapon)
    {
        if (data.ItemCtg != ITEM_CATEGORY.USE) return false;

        switch (data.ItemNumber)
        {
            case 91://체력회복

                break;
            case 92://속도향상
                BuffManager.Instance.AddBuff(data.ItemPower, BUFF_CATEGORY.SPEED);   // 버프, 파워도 전달
                break;
            case 93://공격향상
                BuffManager.Instance.AddBuff(data.ItemPower, BUFF_CATEGORY.ATTACK);
                break;
            case 94://만능총알
                if (Subweapon == null) return false;

                Subweapon.Dbl += (int)(Subweapon.data.MaxDbl * data.ItemPower);
                if (Subweapon.Dbl > Subweapon.data.MaxDbl) Subweapon.Dbl = Subweapon.data.MaxDbl;

                break;
        }

        return true;
    }
}

public class Inventory : MonoBehaviour
{
    int m_nCurWeapon = 0;
    int m_nCurUse = 0;
    int m_nCurEquip = 0;
    INVEN_MODE m_eMode = INVEN_MODE.WEAPON;

    Queue<InventoryItem> m_QueueEmptyItem = new Queue<InventoryItem>();
    List<InventoryItem> m_listUseItem = new List<InventoryItem>();
    List<InventoryItem> m_listWeaponItem = new List<InventoryItem>();
    InventoryItem m_sSubWeapon = null;
    public WeaponList m_sList;

    public InventoryItem SubWeapon { get => m_sSubWeapon; set => m_sSubWeapon = value; }
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
        AddItem(ItemManager.Instance.DictData(GameManager.Instance.PS.DefaultWeaponNum));
        AddItem(ItemManager.Instance.DictData(22));
        AddItem(ItemManager.Instance.DictData(23));
        Equip(m_listWeaponItem[0]);
        AddItem(ItemManager.Instance.DictData(42));
        AddItem(ItemManager.Instance.DictData(92));
        AddItem(ItemManager.Instance.DictData(93));
        AddItem(ItemManager.Instance.DictData(92));
    }

    void MakeNewItemStatus()
    {
        for(int i = 0; i < 10; i++)
            m_QueueEmptyItem.Enqueue(new InventoryItem().Init());
    }

    public bool AddItem(ItemData item)
    {   
        if (item.ItemCtg.Equals(ITEM_CATEGORY.WEAPON)) 
        {
            //보조무기면
            if (item.AtkCtg.Equals(ATK_CATEGORY.SHOT)) 
            {
                m_QueueEmptyItem.Peek().Data = item;
                m_QueueEmptyItem.Peek().Dbl = item.MaxDbl;
                m_sSubWeapon = m_QueueEmptyItem.Dequeue();
                InGameUIManager.Instance.AddImg(m_sSubWeapon.Data.Name);
            }
            //주무기면
            else
            {
                if (m_listWeaponItem.Count >= 5) return false;
                m_QueueEmptyItem.Peek().Data = item;
                m_QueueEmptyItem.Peek().Dbl = item.MaxDbl;
                m_listWeaponItem.Add(m_QueueEmptyItem.Dequeue());
                InGameUIManager.Instance.AddImg(INVEN_MODE.WEAPON, item.Name);
            }
        }

        else if (item.ItemCtg.Equals(ITEM_CATEGORY.USE))
        {
            if (m_listUseItem.Count >= 3) return false;
            m_QueueEmptyItem.Peek().Data = item;
            m_QueueEmptyItem.Peek().Dbl = item.MaxDbl;
            m_listUseItem.Add(m_QueueEmptyItem.Dequeue());
            InGameUIManager.Instance.AddImg(INVEN_MODE.USE, item.Name);
        }

        return true;
    }

    public void Equip(InventoryItem item)
    {
        m_sList.ChangeWeapon(item.Data.Name);
        SendData(item);
    }

    void SendData(InventoryItem item)
    {
        GameManager.Instance.PS.Atk = item.Data.ItemPower;
        GameManager.Instance.PS.AtkSpeed = item.Data.ItemSpd;
        GameManager.Instance.PS.WeaponCategory = item.Data.AtkCtg;
    }

    public void AttackSub()
    {
        m_sList.ChangeSub(m_sSubWeapon.Data.Name);

        m_sSubWeapon.Dbl -= 1;
    }

    public void SubWeaponOff()
    {
        if (m_sSubWeapon.Dbl == 0)
        {
            m_QueueEmptyItem.Enqueue(m_sSubWeapon);
            m_sSubWeapon = null;
            
            InGameUIManager.Instance.DeleteImage();
        }
    }

    public void Attack()
    {
        m_listWeaponItem[m_nCurEquip].Dbl -= 1;

        if (m_listWeaponItem[m_nCurEquip].Dbl.Equals(0))
        {
            m_QueueEmptyItem.Enqueue(m_listWeaponItem[m_nCurEquip]);
            InGameUIManager.Instance.DeleteImage(INVEN_MODE.WEAPON, m_nCurEquip);
            m_listWeaponItem.RemoveAt(m_nCurEquip);
            m_nCurEquip--;
            Equip(m_listWeaponItem[m_nCurEquip]);
        }
    }

    public void Use()
    {
        if (!m_listUseItem[m_nCurUse].UseItem(m_sSubWeapon))
            return;

        InGameUIManager.Instance.DeleteImage(INVEN_MODE.USE, m_nCurUse);
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

        if (m_eMode.Equals(INVEN_MODE.WEAPON))
            KeyAction_WEAPON_MODE();
        else if (m_eMode.Equals(INVEN_MODE.USE)) 
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

            if (m_listWeaponItem[m_nCurWeapon].Dbl.Equals(-1)) return;
           
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
            if (m_nCurWeapon.Equals(m_nCurEquip)) return;
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

    public void ChangeEquip()
    {
        m_sList.ChangeEquip();
    }
}
