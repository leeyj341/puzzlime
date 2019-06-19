using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatus : MonoBehaviour
{
    //무기 스크립트와 소모품 스크립트는 아이템 종류에 따라 적옹됨

    protected short m_nItemNumber;
    protected ITEM_CATEGORY m_eItemCtg;
    protected string m_sName;
    
    public short ItemNumber { get => m_nItemNumber; set => m_nItemNumber = value; }
    public ITEM_CATEGORY ItemCtg { get => m_eItemCtg; set => m_eItemCtg = value; }
    public string ItemName { get => m_sName; set => m_sName = value; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
