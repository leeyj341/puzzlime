using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSystem : MonoBehaviour
{
    Queue<GameObject> m_QueueWeapon = new Queue<GameObject>();
    Queue<GameObject> m_QueueUse = new Queue<GameObject>();

    AirPlaneMovement m_sAPMove;

    public GameObject m_gItemObj;

    float m_fTime;
    float m_fDropCoolTime;
    // Start is called before the first frame update
    private void Start()
    {
        m_sAPMove = gameObject.GetComponent<AirPlaneMovement>();
        m_fDropCoolTime = 60.0f;
        m_fTime = 0.0f;
        QueueSetting();
        ItemManager.Instance.SetSystem(this);
    }

    private void Update()
    {
        AirPlaneTimeUpdate();    
    }

    private void AirPlaneTimeUpdate()
    {
        m_fTime += Time.deltaTime;
        if (m_fTime >= m_fDropCoolTime)
        {
            m_sAPMove.AirPlaneStart();
            m_fTime = 0;
        }
    }
    private void QueueSetting()
    {
        QueueSetting_Use();
        QueueSetting_Weapon();
    }
    private void QueueSetting_Weapon()
    {
        int CtgNum = new int();
        int WeaponNum = new int();

        for(int i = 0; i < 20; i++)
        {
            CtgNum = Random.Range((int)ATK_CATEGORY.HACK, (int)ATK_CATEGORY.NONE);

            if (CtgNum != (int)ATK_CATEGORY.SHOT)
                WeaponNum = Random.Range(0, 3);
            else WeaponNum = Random.Range(0, 2);

            m_QueueWeapon.Enqueue(WeaponSetting(CtgNum, WeaponNum));
        }
    }
    private GameObject WeaponSetting(int ctg, int weapon)
    {
        switch(ctg)
        {
            case (int)ATK_CATEGORY.HACK:
                return WeaponSetting_Hack(weapon);
            case (int)ATK_CATEGORY.STAB:
                return WeaponSetting_Stab(weapon);
            case (int)ATK_CATEGORY.HIT:
                return WeaponSetting_Hit(weapon);
            case (int)ATK_CATEGORY.SHOT:
                return WeaponSetting_Shot(weapon);
        }
        return null;
    }
    private GameObject WeaponSetting_Hack(int Weapon)
    {
        switch(Weapon)
        {
            case 0:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_12"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
            case 1:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_13"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
            case 2:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_14"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
        }
        return null;
    }
    private GameObject WeaponSetting_Stab(int Weapon)
    {
        switch (Weapon)
        {
            case 0:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_22"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
            case 1:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_23"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
            case 2:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_24"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
        }
        return null;
    }
    private GameObject WeaponSetting_Hit(int Weapon)
    {
        switch (Weapon)
        {
            case 0:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_32"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
            case 1:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_33"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
            case 2:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_34"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
        }
        return null;
    }
    private GameObject WeaponSetting_Shot(int Weapon)
    {
        switch (Weapon)
        {
            case 0:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_41"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
            case 1:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_42"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
        }
        return null;
    }
    private void QueueSetting_Use()
    {
        int UseNum = new int();

        for (int i = 0; i < 50; i++)
        {
            UseNum = Random.Range((int)USE_CATEGORY.HEALTHPOTION, (int)USE_CATEGORY.NONE);
            
            m_QueueUse.Enqueue(UseSetting(UseNum));
        }
    }
    private GameObject UseSetting(int Usenum)
    {
        switch (Usenum)
        {
            case 0:
                return (GameObject)Instantiate(Resources.Load("UsePrefabs/Item_91"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
            case 1:
                return (GameObject)Instantiate(Resources.Load("UsePrefabs/Item_92"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
            case 2:
                return (GameObject)Instantiate(Resources.Load("UsePrefabs/Item_93"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);
            case 3:
                return (GameObject)Instantiate(Resources.Load("UsePrefabs/Item_94"), new Vector3(0, 0, 0), Quaternion.identity, m_gItemObj.transform);

        }
        return null;
    }

    public void ItemDrop()
    {
        m_QueueUse.Peek().transform.position = transform.position;
        m_QueueUse.Peek().GetComponent<Rigidbody>().Sleep();
        ItemManager.Instance.AddItemOnField(m_QueueUse.Dequeue());
    }

    public void Recycle(GameObject Item)
    {
        if (Item.GetComponent<ItemStatus>().m_Data.ItemCtg == ITEM_CATEGORY.WEAPON)
            m_QueueWeapon.Enqueue(Item);
        else
            m_QueueUse.Enqueue(Item);
    }
}
