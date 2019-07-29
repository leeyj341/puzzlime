using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    List<Text> buttonTexts = new List<Text>();
    int SaveNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetButton();
    }

    private void SetButton()
    {
        buttonTexts.AddRange(GetComponentsInChildren<Text>());

        if (buttonTexts.Count.Equals(0)) return;
        buttonTexts[1].gameObject.SetActive(false);
    }

    private void ChangeText(bool isClicked)
    {
        buttonTexts[1].gameObject.SetActive(isClicked);
        buttonTexts[0].gameObject.SetActive(!isClicked);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonTexts.Count.Equals(0)) return;
        ChangeText(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (buttonTexts.Count.Equals(0)) return;
        ChangeText(false);
    }

    public void UseStartButton(string nextSceneName)
    {
        if (SaveNum > 1) return;
        SaveLoadManager.Instance.SaveNewPlayerInfoXml("PlayerSaveData" + SaveNum);
        SaveNum++;
        SceneManager.LoadScene(nextSceneName);
    }

    public void UseLoadButton(string nextSceneName)
    {
        // 로드 창 열고, 선택 시 해당 PlayerState 불러오기
        GameManager.Instance.LoadPlayerState("PlayerState");
    }

    public void UseQuitButton()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void UseBackButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void UseBuyButton()
    {
        // PS 갱신상태 저장
    }

    public void UseGoButton()
    {
        // 게임 시작
        LoadingSceneManager.LoadScene("GameScene");
    }

}
