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
        m_nSizeOfItem = 5;
        ItemSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ItemSet()
    {
        for(int i = 0; i < m_nSizeOfItem; i++)
        {
            m_listItem.Add(Instantiate(new GameObject()));
            m_listItem[i].SetActive(false);
        }
    }

    GameObject MakeItem()
    {
        GameObject temp = Instantiate(new GameObject());
        temp.AddComponent<ItemStatus>();
        
        return temp;
    }
}
