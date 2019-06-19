using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    int m_nSizeOfItem;
    List<GameObject> m_listItem = new List<GameObject>();

    private void Awake()
    {
        if (!ItemManager.Instance) Instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject MakeItemObj(ITEM_CATEGORY ctg, short Num)
    {
        GameObject temp = Instantiate(new GameObject());
        if (ctg == ITEM_CATEGORY.WEAPON)
        {
            temp.AddComponent<WeaponScript>();
            temp.GetComponent<WeaponScript>().SetItemObtion(Num);
        }
        else
        {
            temp.AddComponent<UseScript>();
            temp.GetComponent<UseScript>().SetItemObtion(Num);
        }
        return temp;
    }

    WeaponScript MakeWeapon(short num)
    {
        WeaponScript temp = new WeaponScript();
        temp.SetItemObtion(num);
        return temp;
    }

    UseScript MakeUse(short num)
    {
        UseScript temp = new UseScript();
        temp.SetItemObtion(num);
        return temp;
    }
    
    public void AddFirstItem()
    {
    }
}
