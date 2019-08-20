using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    Dictionary<int, ItemData> m_DictItemData = new Dictionary<int, ItemData>();
    List<GameObject> m_listItem = new List<GameObject>();
    ItemDropSystem Sys;

    public ItemData DictData(int Key) { return m_DictItemData[Key]; }

    private void Awake()
    {
        if (!ItemManager.Instance) Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        MakeItemData();
    }

    // Update is called once per frame

    public void SetSystem(ItemDropSystem System)
    {
        Sys = System;
    }

    void MakeItemData()
    {
        AddItemInDict(11, "Data_11");
        AddItemInDict(12, "Data_12");
        AddItemInDict(13, "Data_13");
        AddItemInDict(14, "Data_14");

        AddItemInDict(21, "Data_21");
        AddItemInDict(22, "Data_22");
        AddItemInDict(23, "Data_23");
        AddItemInDict(24, "Data_24");

        AddItemInDict(31, "Data_31");
        AddItemInDict(32, "Data_32");
        AddItemInDict(33, "Data_33");
        AddItemInDict(34, "Data_34");

        AddItemInDict(41, "Data_41");
        AddItemInDict(42, "Data_42");

        AddItemInDict(91, "Data_91");
        AddItemInDict(92, "Data_92");
        AddItemInDict(93, "Data_93");
        AddItemInDict(94, "Data_94");

#if UNITY_EDITOR
        AssetDatabase.SaveAssets();
#endif
    }

    void AddItemInDict(int Key, string FileName)
    {
#if UNITY_EDITOR
        ItemData Temp = AssetDatabase.LoadAssetAtPath<ItemData>("Assets/Resources/Data/" + FileName + ".asset");
        if (Temp)
        {
            m_DictItemData.Add(Key, Temp);
        }
        else
        {
            m_DictItemData.Add(Key, ScriptableObject.CreateInstance<ItemData>().SetItemObtion(Key));
            AssetDatabase.CreateAsset(m_DictItemData[Key], "Assets/Resources/Data/" + FileName + ".asset");
        }

#else
        ItemData Temp = Resources.Load<ItemData>("Data/" + FileName);
        m_DictItemData.Add(Key, Temp);
#endif
    }

    public void AddItemOnField(GameObject Item)
    {
        m_listItem.Add(Item);
        Item.SetActive(true);
        Item.GetComponent<ItemStatus>().ActivateItem(true);
    }

    public void DelItemOnField(GameObject Item)
    {
        m_listItem.Remove(Item);
        Sys.Recycle(Item);
        Item.SetActive(false);
    }
}
