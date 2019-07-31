using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    List<Text> buttonTexts = new List<Text>();

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
        GameManager.Instance.PS.Initialize();
        SceneManager.LoadScene(nextSceneName);
        //save
        //SaveInfo si = new SaveInfo();
        //SaveLoadManager.Instance.SavePlayerInfoAsXml(si);
    }

    public void UseLoadButton()
    {
        // 로드 창 열고, 선택 시 해당 PlayerState 불러오기
        GameManager.Instance.PS.Set(SaveLoadManager.Instance.LoadPlayerInfoAsXml<SaveInfo>(1));

    }

    public void LoadPlayerInfo()
    {
        //GetComponentInChildren<GameObject>();
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
