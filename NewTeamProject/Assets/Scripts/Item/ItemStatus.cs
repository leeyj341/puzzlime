using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatus : MonoBehaviour
{
    Rigidbody m_cRb;
    Transform m_cPos;
    //무기 스크립트와 소모품 스크립트는 아이템 종류에 따라 적옹됨
    private WeaponScript m_cWS = null;
    private UseScript m_cUS = null;
    private bool m_bisWeapon = true;
    public short m_nItemNumber;
    private ITEM_CATEGORY m_eItemCtg;
    private string m_sName;

    public WeaponScript WS { get => m_cWS; set => m_cWS = value; } 
    public UseScript US { get => m_cUS; set => m_cUS = value; }
    public bool IsWeapon { get => m_bisWeapon; set => m_bisWeapon = value; }
    
    public ITEM_CATEGORY ItemCtg { get => m_eItemCtg; set => m_eItemCtg = value; }
    public string ItemName { get => m_sName; set => m_sName = value; }

    // Start is called before the first frame update
    void Start()
    {
        m_cRb = GetComponent<Rigidbody>();
        m_cPos = GetComponent<Transform>();
        //아이템 스크립트 적용부분
        if (m_eItemCtg == ITEM_CATEGORY.WEAPON)
        {
            m_cWS = gameObject.AddComponent<WeaponScript>();
        }
        else if (m_eItemCtg == ITEM_CATEGORY.USE)
        {
            m_cUS = gameObject.AddComponent<UseScript>();
            m_bisWeapon = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetName(string name)
    {
        m_sName = name;
    }
}
