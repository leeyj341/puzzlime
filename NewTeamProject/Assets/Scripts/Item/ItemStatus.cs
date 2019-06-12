using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatus : MonoBehaviour
{
    //무기 스크립트와 소모품 스크립트는 아이템 종류에 따라 적옹됨
    private WeaponScript m_cWS = null;
    private UseScript m_cUS = null;
    private short m_nItemNumber;
    private ITEM_CATEGORY m_eItemCtg;
    private string m_sName;

    public WeaponScript WS { get => m_cWS; set => m_cWS = value; } 
    public UseScript US { get => m_cUS; set => m_cUS = value; }
    public short ItemNubmer { get => m_nItemNumber; set => m_nItemNumber = value; }
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

    public void ItemSet(ITEM_CATEGORY itemctg, int ItemNum)
    {
        m_eItemCtg = itemctg;
        if(m_eItemCtg == ITEM_CATEGORY.WEAPON)
        {
            m_cWS = gameObject.AddComponent<WeaponScript>();
            m_cWS.SetItemObtion(ItemNum);
        }
        else if(m_eItemCtg == ITEM_CATEGORY.USE)
        {
            m_cUS = gameObject.AddComponent<UseScript>();
            m_cUS.SetItemObtion(ItemNum);
        }
    }
}
