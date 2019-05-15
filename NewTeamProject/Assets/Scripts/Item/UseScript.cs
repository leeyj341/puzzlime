using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseScript : MonoBehaviour
{
    USE_CATEGORI m_eUseCtg; // 사용 아이템 종류
    float m_fDbl; // 내구도, 지속시간을 뜻함

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
    void SetItemObtion()
    {
        int num = gameObject.GetComponent<ItemStatus>().m_nItemNumber;
        switch(num)
        {
            case 91:
                gameObject.GetComponent<ItemStatus>().SetName("체력회복물약");
                m_eUseCtg = USE_CATEGORI.HEALTHPOTION;
                m_fDbl = 0;
                break;
            case 92:
                gameObject.GetComponent<ItemStatus>().SetName("속도향상물약");
                m_eUseCtg = USE_CATEGORI.SPEEDPOTION;
                m_fDbl = 10;
                break;
            case 93:
                gameObject.GetComponent<ItemStatus>().SetName("공격향상물약");
                m_eUseCtg = USE_CATEGORI.POWERPOTION;
                m_fDbl = 15;
                break;
            case 94:
                gameObject.GetComponent<ItemStatus>().SetName("만능총알");
                m_eUseCtg = USE_CATEGORI.BULLET;
                m_fDbl = 20;
                break;
        }
    }
    //아이템 사용시의 효과를 적용하는 함수
    //BuffManager에 버프를 전달해서 적용함
    public void ActiveItem()
    {
        switch(m_eUseCtg)
        {
            case USE_CATEGORI.BULLET:
                BuffManager.Instance.AddBuff(m_fDbl, BUFF_CATEGORI.BULLET);
                break;
            case USE_CATEGORI.HEALTHPOTION:
                //플레이어 체력 회복 코드 삽입부분
                break;
            case USE_CATEGORI.POWERPOTION:
                BuffManager.Instance.AddBuff(m_fDbl, BUFF_CATEGORI.ATTACK);
                break;
            case USE_CATEGORI.SPEEDPOTION:
                BuffManager.Instance.AddBuff(m_fDbl, BUFF_CATEGORI.SPEED);
                break;
        }
    }
}
