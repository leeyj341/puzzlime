using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContainer : MonoBehaviour
{
    public static BulletContainer Instance;

    List<GameObject> m_listBullet = new List<GameObject>();

    private void Awake()
    {
        if (!Instance) Instance = this;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        MakeBullet();   
    }

    public void MakeBullet()
    {
        for(int i = 0; i < 20; i++)
        {
            GameObject temp = (GameObject)Instantiate(Resources.Load("WeaponPrefabs/Bullet"));
            m_listBullet.Add(temp);
        }
    }
    
    public void Fire(float damage, float range, Transform tpPlayer)
    {
        GameObject CurBulletObj = FindBullet();
        if (!CurBulletObj) return;
        Bullet CurBullet = CurBulletObj.GetComponent<Bullet>();
        CurBulletObj.SetActive(true);
        CurBulletObj.transform.rotation = tpPlayer.rotation;
        CurBulletObj.transform.position = tpPlayer.position;
        CurBullet.Fire(damage, range);
    }

    GameObject FindBullet()
    {
        for(int i = 0; i < m_listBullet.Count; i++)
        {
            if (m_listBullet[i].activeSelf) return m_listBullet[i];
        }

        return null;
    }
}
