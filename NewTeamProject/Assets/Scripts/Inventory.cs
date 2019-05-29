using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    bool m_bIsWeaponMode = true;
    List<ItemStatus> m_listUseItem = new List<ItemStatus>();
    List<ItemStatus> m_listWeaponItem = new List<ItemStatus>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getWeaponMode()
    {
        return m_bIsWeaponMode;
    }

    public void AddItem(ItemStatus item)
    {
        
    }
}
