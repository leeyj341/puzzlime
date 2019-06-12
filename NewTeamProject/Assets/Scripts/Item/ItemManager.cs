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

    GameObject MakeItemObj(ITEM_CATEGORY ctg, int Num)
    {
        GameObject temp = Instantiate(new GameObject());
        temp.AddComponent<ItemStatus>();
        temp.GetComponent<ItemStatus>().ItemSet(ctg, Num);
        return temp;
    }

    ItemStatus MakeItem(ITEM_CATEGORY ctg, int Num)
    {
        ItemStatus Temp = new ItemStatus();
        Temp.ItemSet(ctg, Num);
        return Temp;
    }

    public void AddFirstItem()
    {

        GameManager.Instance.Inven.AddItem(MakeItem(ITEM_CATEGORY.WEAPON, 11));
        GameManager.Instance.Inven.AddItem(MakeItem(ITEM_CATEGORY.WEAPON, 41));
    }
}
