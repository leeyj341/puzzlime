using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    ATK_CATEGORI m_eAtkCtg;
    float m_fItemAtk;
    float m_fItemSpd;
    
    int m_ndbl; //내구도
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //무기의 내구도가 다하면 false를 반환함
    public bool Consum()
    {
        if(m_ndbl > 0)
            m_ndbl--;
        if (m_ndbl == 0) return false;
        return true;
    }
    //무기의 정보를 플레이어에게로 보내는 함수.
    void SendData()
    {
        
    }
    //시리얼 넘버에 해당하는 아이템 정보를 입력하는 함수
    //11~14 : 베기, 21~24 : 찌르기, 31~34 : 때리기, 41~44 사격
    void SetItemObtion()
    {
        int Num = new int();
        Num = gameObject.GetComponent<ItemStatus>().m_nItemNumber;

        switch (Num / 10)
        {
            case 1:
                SetItemObtion_Hack(Num);
                break;
            case 2:
                SetItemObtion_Step(Num);
                break;
            case 3:
                SetItemObtion_Hit(Num);
                break;
            case 4:
                SetItemObtion_Shot(Num);
                break;
        }
    }
    //아래 함수들은 ItemStatus에서 받아온 번호를 기반으로 무기의 종류별 데이터를 삽입하는 부분
    void SetItemObtion_Hack(int num)
    {
        switch(num)
        {
            case 11:
                gameObject.GetComponent<ItemStatus>().SetName("질낮은 칼");
                m_eAtkCtg = ATK_CATEGORI.HACK;
                m_fItemAtk = 8;
                m_fItemSpd = 1;
                m_ndbl = -1;
                break;
            case 12:
                gameObject.GetComponent<ItemStatus>().SetName("일본도");
                m_eAtkCtg = ATK_CATEGORI.HACK;
                m_fItemAtk = 10;
                m_fItemSpd = 0.8f;
                m_ndbl = 50;
                break;
            case 13:
                gameObject.GetComponent<ItemStatus>().SetName("수정검");
                m_eAtkCtg = ATK_CATEGORI.HACK;
                m_fItemAtk = 13;
                m_fItemSpd = 1;
                m_ndbl = 25;
                break;
            case 14:
                gameObject.GetComponent<ItemStatus>().SetName("수정대검");
                m_eAtkCtg = ATK_CATEGORI.HACK;
                m_fItemAtk = 20;
                m_fItemSpd = 2;
                m_ndbl = 10;
                break;
        }
    }

    void SetItemObtion_Step(int num)
    {
        switch(num)
        {
            case 21:
                gameObject.GetComponent<ItemStatus>().SetName("이 나간 검");
                m_eAtkCtg = ATK_CATEGORI.STEP;
                m_fItemAtk = 8;
                m_fItemSpd = 1;
                m_ndbl = -1;
                break;
            case 22:
                gameObject.GetComponent<ItemStatus>().SetName("차");
                m_eAtkCtg = ATK_CATEGORI.STEP;
                m_fItemAtk = 5;
                m_fItemSpd = 0.4f;
                m_ndbl = 50;
                break;
            case 23:
                gameObject.GetComponent<ItemStatus>().SetName("치도");
                m_eAtkCtg = ATK_CATEGORI.STEP;
                m_fItemAtk = 15;
                m_fItemSpd = 1.5f;
                m_ndbl = 25;
                break;
            case 24:
                gameObject.GetComponent<ItemStatus>().SetName("수정장창");
                m_eAtkCtg = ATK_CATEGORI.STEP;
                m_fItemAtk = 20;
                m_fItemSpd = 2;
                m_ndbl = 10;
                break;
        }
    }

    void SetItemObtion_Hit(int num)
    {
        switch (num)
        {
            case 31:
                gameObject.GetComponent<ItemStatus>().SetName("빗자루");
                m_eAtkCtg = ATK_CATEGORI.HIT;
                m_fItemAtk = 8;
                m_fItemSpd = 1;
                m_ndbl = -1;
                break;
            case 32:
                gameObject.GetComponent<ItemStatus>().SetName("곤봉");
                m_eAtkCtg = ATK_CATEGORI.HIT;
                m_fItemAtk = 12;
                m_fItemSpd = 1.3f;
                m_ndbl = 50;
                break;
            case 33:
                gameObject.GetComponent<ItemStatus>().SetName("신기한 막대");
                m_eAtkCtg = ATK_CATEGORI.HIT;
                m_fItemAtk = 15;
                m_fItemSpd = 1.2f;
                m_ndbl = 20;
                break;
            case 34:
                gameObject.GetComponent<ItemStatus>().SetName("대두");
                m_eAtkCtg = ATK_CATEGORI.HIT;
                m_fItemAtk = 22;
                m_fItemSpd = 2.5f;
                m_ndbl = 10;
                break;
        }
    }

    void SetItemObtion_Shot(int num)
    {
        switch (num)
        {
            case 41:
                gameObject.GetComponent<ItemStatus>().SetName("조잡한 활");
                m_eAtkCtg = ATK_CATEGORI.SHOT;
                m_fItemAtk = 4;
                m_fItemSpd = 1;
                m_ndbl = -1;
                break;
            case 42:
                gameObject.GetComponent<ItemStatus>().SetName("보급 총");
                m_eAtkCtg = ATK_CATEGORI.SHOT;
                m_fItemAtk = 5;
                m_fItemSpd = 0.8f;
                m_ndbl = 50;
                break;
            case 43:
                gameObject.GetComponent<ItemStatus>().SetName("여섯발에 여섯놈");
                m_eAtkCtg = ATK_CATEGORI.SHOT;
                m_fItemAtk = 12;
                m_fItemSpd = 1;
                m_ndbl = 6;
                break;
            case 44:
                gameObject.GetComponent<ItemStatus>().SetName("한발에 한놈");
                m_eAtkCtg = ATK_CATEGORI.SHOT;
                m_fItemAtk = 25;
                m_fItemSpd = 3.5f;
                m_ndbl = 1;
                break;
        }
    }
}
