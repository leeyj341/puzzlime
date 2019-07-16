using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    List<ItemData> m_listItemData = new List<ItemData>();

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
    
    void MakeItemData()
    {
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(11));
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(12));
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(13));
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(14));

        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(21));
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(22));
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(23));
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(24));

        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(31));
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(32));
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(33));
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(34));

        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(41));
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(42));

        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(91));
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(92));
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(93));
        m_listItemData.Add(ScriptableObject.CreateInstance<ItemData>().SetItemObtion(94));
    }
}
