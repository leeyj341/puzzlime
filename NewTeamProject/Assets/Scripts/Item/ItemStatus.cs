using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatus : MonoBehaviour
{
    Rigidbody m_cRb;
    Transform m_cPos;
    //무기 스크립트와 소모품 스크립트는 아이템 종류에 따라 적옹됨
    WeaponScript m_cWS = null;
    UseScript m_cUS = null;

    public short m_nItemNumber;
    public ITEM_CATEGORI m_eItemCtg;
    private string m_sName;

    // Start is called before the first frame update
    void Start()
    {
        m_cRb = GetComponent<Rigidbody>();
        m_cPos = GetComponent<Transform>();
        //아이템 스크립트 적용부분
        if (m_eItemCtg == ITEM_CATEGORI.WEAPON) m_cWS = gameObject.AddComponent<WeaponScript>();
        else if (m_eItemCtg == ITEM_CATEGORI.USE) m_cUS = gameObject.AddComponent<UseScript>();
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
