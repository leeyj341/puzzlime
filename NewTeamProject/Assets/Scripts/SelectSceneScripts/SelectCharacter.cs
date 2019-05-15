﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectCharacter : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Select();
    }

    private void Select()
    {
        if (EnumScripts.CharacterList.Contains(tag))
        {
            //캐릭터 선택 정보 전달, scene 전환
            SceneManager.LoadScene("GameScene");
        }
    }
}
