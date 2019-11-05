using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContainer : MonoBehaviour
{
    public static BulletContainer Instance;

    List<GameObject> m_listBullet_41 = new List<GameObject>();
    List<GameObject> m_listBullet_42 = new List<GameObject>();
    List<Arrow> m_ListArrow = new List<Arrow>();

    private void Awake()
    {
        if (!Instance) Instance = this;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadArrow();
        MakeBullet();   
    }

    public void BulletOff()
    {
        for(int i = 0; i < m_listBullet_41.Count; i++)
        {
            m_listBullet_41[i].SetActive(false);
            m_listBullet_42[i].SetActive(false);
        }
    }

    public void MakeBullet()
    {
        for(int i = 0; i < 20; i++)
        {
            m_listBullet_41.Add(MakeBullet_41());
            m_listBullet_42.Add(MakeBullet_42());
        }
    }

    public void LoadArrow()
    {
        m_ListArrow.AddRange(GetComponentsInChildren<Arrow>(true));
    }

    GameObject MakeBullet_41()
    {
        GameObject temp = (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Bullet"), transform);
        temp.GetComponent<Bullet>().Type = BULLET_TYPE.TYPE_41;
        temp.GetComponent<Bullet>().Range = 50.0f;
        temp.GetComponent<Bullet>().GetComponent<Rigidbody>().useGravity = false;
        temp.GetComponent<Bullet>().GetComponent<Rigidbody>().mass = 0.1f;
        return temp;
    }

    GameObject MakeBullet_42()
    {
        GameObject temp = (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Bullet"), transform);
        temp.GetComponent<Bullet>().Type = BULLET_TYPE.TYPE_42;
        temp.GetComponent<Bullet>().Range = 50.0f;
        temp.GetComponent<Bullet>().GetComponent<Rigidbody>().useGravity = true;
        temp.GetComponent<Bullet>().GetComponent<Rigidbody>().mass = 0.5f;
        return temp;
    }

    public void Fire()
    {
        GameObject CurBulletObj = FindBullet(GameManager.Instance.Inven.SubWeapon.Data.ItemNumber);
        if (!CurBulletObj) return;
        Bullet CurBullet = CurBulletObj.GetComponent<Bullet>();
        CurBulletObj.SetActive(true);
        CurBulletObj.GetComponent<Bullet>().Fire(GameManager.Instance.Inven.SubWeapon.Data.ItemPower);
    }

    public void FireArrow(Transform monsterTransform)
    {
        for(int i = 0; i < m_ListArrow.Count; i++)
        {
            if(!m_ListArrow[i].gameObject.activeInHierarchy)
            {
                m_ListArrow[i].gameObject.SetActive(true);
                m_ListArrow[i].Range = 50.0f;
                m_ListArrow[i].FireArrow(10.0f, monsterTransform);
                return;
            }
        }
    }

    GameObject FindBullet(int SubNum)
    {
        if(SubNum == 41)
        {
            for (int i = 0; i < m_listBullet_41.Count; i++)
            {
                if (!m_listBullet_41[i].activeSelf)
                    return m_listBullet_41[i];
            }
        }

        else if(SubNum == 42)
        {
            for (int i = 0; i < m_listBullet_42.Count; i++)
            {
                if (!m_listBullet_42[i].activeSelf)
                    return m_listBullet_42[i];
            }
        }

        return null;
    }
}
