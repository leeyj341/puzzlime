using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSystem : MonoBehaviour
{
    static ItemDropSystem instance;

    Queue<GameObject> m_QueueEmptyItem = new Queue<GameObject>();
    
    public Queue<GameObject> QueueEmptyItem { get; set; }

    private void Awake()
    {
        if (!instance) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject temp = 
                (GameObject)Instantiate(Resources.Load("WeaponPrefabs/RandomItem"), new Vector3(0, 0, 0), Quaternion.identity);
            temp.GetComponent<ItemStatus>().ActivateItem(true);
            temp.SetActive(false);
            m_QueueEmptyItem.Enqueue(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ItemSetting()
    {
        
    }
}
