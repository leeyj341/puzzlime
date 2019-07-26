using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ItemData")]
public class ItemData : ScriptableObject
{
    public int ItemNumber = 0;
    public string Name = "";
    public ITEM_CATEGORY ItemCtg = ITEM_CATEGORY.NONE;
    public ATK_CATEGORY AtkCtg = ATK_CATEGORY.NONE;
    public USE_CATEGORY UseCtg = USE_CATEGORY.NONE;
    public float ItemPower = 0.0f;
    public float ItemSpd = 0.0f;
    public int MaxDbl = 0;
    
    public ItemData SetItemObtion(int num)
    {
        ItemNumber = num;
        switch (ItemNumber)
        {
            case 11:
                Name = "질 낮은 칼";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.HACK;
                ItemPower = 3;
                ItemSpd = 1;
                MaxDbl = -1;
                break;
            case 12:
                Name = "일본도";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.HACK;
                ItemPower = 5;
                ItemSpd = 1.2f;
                MaxDbl = 40;
                break;
            case 13:
                Name = "수정검";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.HACK;
                ItemPower = 7;
                ItemSpd = 1;
                MaxDbl = 25;
                break;
            case 14:
                Name = "수정대검";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.HACK;
                ItemPower = 14;
                ItemSpd = 0.5f;
                MaxDbl = 10;
                break;
            case 21:
                Name = "이 나간 검";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.STAB;
                ItemPower = 5;
                ItemSpd = 1;
                MaxDbl = -1;
                break;
            case 22:
                Name = "차";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.STAB;
                ItemPower = 5;
                ItemSpd = 1.6f;
                MaxDbl = 40;
                break;
            case 23:
                Name = "치도";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.STAB;
                ItemPower = 10;
                ItemSpd = 0.9f;
                MaxDbl = 25;
                break;
            case 24:
                Name = "수정장창";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.STAB;
                ItemPower = 20;
                ItemSpd = 0.5f;
                MaxDbl = 10;
                break;
            case 31:
                Name = "빗자루";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.HIT;
                ItemPower = 6;
                ItemSpd = 0.5f;
                MaxDbl = -1;
                break;
            case 32:
                Name = "곤봉";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.HIT;
                ItemPower = 9;
                ItemSpd = 0.7f;
                MaxDbl = 40;
                break;
            case 33:
                Name = "신기한 막대";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.HIT;
                ItemPower = 12;
                ItemSpd = 0.6f;
                MaxDbl = 25;
                break;
            case 34:
                Name = "대두";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.HIT;
                ItemPower = 24;
                ItemSpd = 0.3f;
                MaxDbl = 10;
                break;
            case 41:
                Name = "피스톨";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.SHOT;
                ItemPower = 2;
                ItemSpd = 1.5f;
                MaxDbl = 20;
                break;
            case 42:
                Name = "리볼버";
                ItemCtg = ITEM_CATEGORY.WEAPON;
                AtkCtg = ATK_CATEGORY.SHOT;
                ItemPower = 6;
                ItemSpd = 1;
                MaxDbl = 6;
                break;
            case 91:
                Name = "체력회복물약";
                ItemCtg = ITEM_CATEGORY.USE;
                UseCtg = USE_CATEGORY.HEALTHPOTION;
                ItemPower = 0.2f;
                break;
            case 92:
                Name = "속도향상물약";
                ItemCtg = ITEM_CATEGORY.USE;
                UseCtg = USE_CATEGORY.SPEEDPOTION; // 버프
                ItemPower = 0.2f;           // 추가 비율
                MaxDbl = 20;                // 지속 시간 (초)
                break;
            case 93:
                Name = "공격향상물약";
                ItemCtg = ITEM_CATEGORY.USE;
                UseCtg = USE_CATEGORY.POWERPOTION;
                ItemPower = 0.2f;
                MaxDbl = 20;
                break;
            case 94:
                Name = "만능총알";
                ItemCtg = ITEM_CATEGORY.USE;
                UseCtg = USE_CATEGORY.BULLET;
                ItemPower = 0.2f;
                break;
        }
        return this;
    }
}
