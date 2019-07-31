using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CURRUNT_SCENE
{
    SCENE_MAIN,
    SCENE_SELECT,
    SCENE_SHOP,
    SCENE_GAME,
    SCENE_LOADING
}

public enum ITEM_CATEGORY
{
    WEAPON,
    USE,
    NONE
}

public enum ATK_CATEGORY
{
    HACK,
    HIT,
    STAB,
    SHOT,
    NONE
}

public enum USE_CATEGORY
{
    HEALTHPOTION,
    SPEEDPOTION,
    POWERPOTION,
    BULLET,
    NONE
}

public enum BUFF_CATEGORY
{
    SPEED,
    ATTACK
}

public enum ANIM_SORT
{
    ATTACK,
    SHOOT,
    BASIC
}

public enum INVEN_MODE
{
    WEAPON,
    USE
}

public static class Constants
{
    public const float GameTime = 900.0f;
    public const int SaveSlotNum = 2;
}