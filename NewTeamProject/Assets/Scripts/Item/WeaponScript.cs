
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : ItemStatus
{
    ATK_CATEGORY m_eAtkCtg;
    float m_fItemAtk;
    float m_fItemSpd;
    int m_nMaxDbl;
    int m_nDbl; //내구도
    
    public ATK_CATEGORY AtkCtg { get => m_eAtkCtg; }
    public float Atk { get => m_fItemAtk; }
    public float Spd { get => m_fItemSpd; }
    public int MaxDbl { get => m_nMaxDbl; }
    public int Dbl { get => m_nDbl; set => m_nDbl = value; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //시리얼 넘버에 해당하는 아이템 정보를 입력하는 함수
    //11~14 : 베기, 21~24 : 찌르기, 31~34 : 때리기, 41~44 사격
    public void SetItemObtion(short Num)
    {
        switch (Num / 10)
        {
            case 1:
                SetItemObtion_Hack(Num);
                break;
            case 2:
                SetItemObtion_Stab(Num);
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
    void SetItemObtion_Hack(short num)
    {
        switch(num)
        {
            case 11:
                m_sName = "질 낮은 칼";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.HACK;
                m_fItemAtk = 3;
                m_fItemSpd = 1;
                m_nDbl = -1;
                break;
            case 12:
                m_sName = "일본도";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.HACK;
                m_fItemAtk = 5;
                m_fItemSpd = 1.2f;
                m_nDbl = 40;
                break;
            case 13:
                m_sName = "수정검";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.HACK; m_fItemAtk = 7;
                m_fItemSpd = 1;
                m_nDbl = 25;
                break;
            case 14:
                m_sName = "수정대검";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.HACK;
                m_fItemAtk = 14;
                m_fItemSpd = 0.5f;
                m_nDbl = 10;
                break;
        }
    }

    void SetItemObtion_Stab(short num)
    {
        switch(num)
        {
            case 21:
                m_sName = "이 나간 검";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.STAB;
                m_fItemAtk = 5;
                m_fItemSpd = 1;
                m_nDbl = -1;
                break;
            case 22:
                m_sName = "차";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.STAB;
                m_fItemAtk = 5;
                m_fItemSpd = 1.6f;
                m_nDbl = 40;
                break;
            case 23:
                m_sName = "치도";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.STAB;
                m_fItemAtk = 10;
                m_fItemSpd = 0.9f;
                m_nDbl = 25;
                break;
            case 24:
                m_sName = "수정장창";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.STAB;
                m_fItemAtk = 20;
                m_fItemSpd = 0.5f;
                m_nDbl = 10;
                break;
        }
    }

    void SetItemObtion_Hit(short num)
    {
        switch (num)
        {
            case 31:
                m_sName = "빗자루";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.HIT;
                m_fItemAtk = 6;
                m_fItemSpd = 0.5f;
                m_nDbl = -1;
                break;
            case 32:
                m_sName = "곤봉";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.HIT;
                m_fItemAtk = 9;
                m_fItemSpd = 0.7f;
                m_nDbl = 40;
                break;
            case 33:
                m_sName = "신기한 막대";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.HIT;
                m_fItemAtk = 12;
                m_fItemSpd = 0.6f;
                m_nDbl = 25;
                break;
            case 34:
                m_sName = "대두";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.HIT;
                m_fItemAtk = 24;
                m_fItemSpd = 0.3f;
                m_nDbl = 10;
                break;
        }
    }

    void SetItemObtion_Shot(short num)
    {
        switch (num)
        {
            case 41:
                m_sName = "피스톨";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.SHOT;
                m_fItemAtk = 2;
                m_fItemSpd = 1.5f;
                m_nDbl = 20;
                break;
            case 42:
                m_sName = "리볼버";
                m_eItemCtg = ITEM_CATEGORY.WEAPON;
                m_nItemNumber = num;
                m_eAtkCtg = ATK_CATEGORY.SHOT;
                m_fItemAtk = 6;
                m_fItemSpd = 1;
                m_nDbl = 6;
                break;
        }
    }
}
