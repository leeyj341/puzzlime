using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseScript : ItemStatus
{
    USE_CATEGORY m_eUseCtg; // 사용 아이템 종류
    float m_fPower; // 내구도, 지속시간을 뜻함

    public USE_CATEGORY UseCtg { get => m_eUseCtg; set => m_eUseCtg = value; }
    public float Power { get => m_fPower; set => m_fPower = value; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //아이템 옵션 결정
    //ItemStatus에 입력한 아이템 넘버를 기반으로 91~94번까지의 번호를 받아 작동함
    public void SetItemObtion(short num)
    {
        switch(num)
        {
            case 91:
                m_sName = "체력회복물약";
                m_eItemCtg = ITEM_CATEGORY.USE;
                m_nItemNumber = num;
                m_eUseCtg = USE_CATEGORY.HEALTHPOTION;
                m_fPower = 0;
                break;
            case 92:
                m_sName = "속도향상물약";
                m_eItemCtg = ITEM_CATEGORY.USE;
                m_nItemNumber = num;
                m_eUseCtg = USE_CATEGORY.SPEEDPOTION;
                m_fPower = 10;
                break;
            case 93:
                m_sName = "공격향상물약";
                m_eItemCtg = ITEM_CATEGORY.USE;
                m_nItemNumber = num;
                m_eUseCtg = USE_CATEGORY.POWERPOTION;
                m_fPower = 15;
                break;
            case 94:
                m_sName = "만능총알";
                m_eItemCtg = ITEM_CATEGORY.USE;
                m_nItemNumber = num;
                m_eUseCtg = USE_CATEGORY.BULLET;
                m_fPower = 0;
                break;
        }
    }
}
