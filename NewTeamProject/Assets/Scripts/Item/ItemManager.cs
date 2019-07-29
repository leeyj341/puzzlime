using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public Dictionary<int, ItemData> m_DictItemData = new Dictionary<int, ItemData>();

    public ItemData DictData(int Key) { return m_DictItemData[Key]; }

    private void Awake()
    {
        if (!ItemManager.Instance) Instance = this;

        MakeItemData();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Inven.FirstSetting();
    }

    // Update is called once per frame
    void Update()
    {

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

        AssetDatabase.SaveAssets();
    }
    
    void AddItemInDict(int Key, string FileName)
    {
        ItemData temp = AssetDatabase.LoadAssetAtPath<ItemData>("Assets/Data/" + FileName + ".asset");
        if (!temp)
        {
            AssetDatabase.CreateAsset(temp, "Assets/Data/" + FileName + ".asset");
            m_DictItemData.Add(Key, temp.SetItemObtion(Key));
        }

        else
        {
            m_DictItemData.Add(Key, temp);
        }
    }
}
