using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseScript : MonoBehaviour
{
    USE_CATEGORY m_eUseCtg; // 사용 아이템 종류
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
    public void SetItemObtion(int num)
    {
        switch(num)
        {
            case 91:
                gameObject.GetComponent<ItemStatus>().ItemName = "체력회복물약";
                m_eUseCtg = USE_CATEGORY.HEALTHPOTION;
                m_fDbl = 0;
                break;
            case 92:
                gameObject.GetComponent<ItemStatus>().ItemName = "속도향상물약";
                m_eUseCtg = USE_CATEGORY.SPEEDPOTION;
                m_fDbl = 10;
                break;
            case 93:
                gameObject.GetComponent<ItemStatus>().ItemName = "공격향상물약";
                m_eUseCtg = USE_CATEGORY.POWERPOTION;
                m_fDbl = 15;
                break;
            case 94:
                gameObject.GetComponent<ItemStatus>().ItemName = "만능총알";
                m_eUseCtg = USE_CATEGORY.BULLET;
                m_fDbl = 0;
                break;
        }
    }
    //아이템 사용시의 효과를 적용하는 함수
    //BuffManager에 버프를 전달해서 적용함
    public bool ActiveItem(ItemStatus SubWeapon)
    {
        bool Work = true;
        switch(m_eUseCtg)
        {
            case USE_CATEGORY.BULLET:
                if (!SubWeapon)
                    return Work = false;
                SubWeapon.WS.Dbl = SubWeapon.WS.Dbl + SubWeapon.WS.MaxDbl / 3;
                break;
            case USE_CATEGORY.HEALTHPOTION:
                if (GameManager.Instance.PS.MaxHp > GameManager.Instance.PS.Hp)
                    GameManager.Instance.PS.Hp += 3;

                if (GameManager.Instance.PS.MaxHp < GameManager.Instance.PS.Hp)
                    GameManager.Instance.PS.Hp = GameManager.Instance.PS.MaxHp;
                    break;
            case USE_CATEGORY.POWERPOTION:
                BuffManager.Instance.AddBuff(m_fDbl, BUFF_CATEGORY.ATTACK);
                break;
            case USE_CATEGORY.SPEEDPOTION:
                BuffManager.Instance.AddBuff(m_fDbl, BUFF_CATEGORY.SPEED);
                break;
        }

        return Work;
    }
}
