using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDropSystem", menuName = "Data/ItemDropSystem", order = 2)]
public class ItemDropSystem : ScriptableObject
{
    Queue<GameObject> m_QueueWeapon = new Queue<GameObject>();
    Queue<GameObject> m_QueueUse = new Queue<GameObject>();

    // Start is called before the first frame update
   
    public void QueueSetting_Weapon()
    {
        int CtgNum = new int();
        int WeaponNum = new int();

        for(int i = 0; i < 40; i++)
        {
            CtgNum = Random.Range((int)ATK_CATEGORY.HACK, (int)ATK_CATEGORY.SHOT);

            if (CtgNum != (int)ATK_CATEGORY.SHOT)
                WeaponNum = Random.Range(0, 2);
            else WeaponNum = Random.Range(0, 1);

            m_QueueWeapon.Enqueue(WeaponSetting(CtgNum, WeaponNum));
        }
    }
    
    GameObject WeaponSetting(int ctg, int weapon)
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

    GameObject WeaponSetting_Hack(int Weapon)
    {
        switch(Weapon)
        {
            case 0:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_12"), new Vector3(0, 0, 0), Quaternion.identity);
            case 1:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_13"), new Vector3(0, 0, 0), Quaternion.identity);
            case 2:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_14"), new Vector3(0, 0, 0), Quaternion.identity);
        }
        return null;
    }

    GameObject WeaponSetting_Stab(int Weapon)
    {
        switch (Weapon)
        {
            case 0:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_22"), new Vector3(0, 0, 0), Quaternion.identity);
            case 1:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_23"), new Vector3(0, 0, 0), Quaternion.identity);
            case 2:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_24"), new Vector3(0, 0, 0), Quaternion.identity);
        }
        return null;
    }
    GameObject WeaponSetting_Hit(int Weapon)
    {
        switch (Weapon)
        {
            case 0:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_32"), new Vector3(0, 0, 0), Quaternion.identity);
            case 1:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_33"), new Vector3(0, 0, 0), Quaternion.identity);
            case 2:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_34"), new Vector3(0, 0, 0), Quaternion.identity);
        }
        return null;
    }
    GameObject WeaponSetting_Shot(int Weapon)
    {
        switch (Weapon)
        {
            case 0:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_41"), new Vector3(0, 0, 0), Quaternion.identity);
            case 1:
                return (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Item_42"), new Vector3(0, 0, 0), Quaternion.identity);
        }
        return null;
    }

    void QueueSetting_Use()
    {

    }
    
}
