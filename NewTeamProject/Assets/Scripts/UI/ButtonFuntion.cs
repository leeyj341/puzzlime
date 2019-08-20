using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFuntion : MonoBehaviour
{
    public void UseStartButton(string nextSceneName)
    {
        GameManager.Instance.PS.Initialize();
        SceneManager.LoadScene(nextSceneName);
        //save
        //SaveInfo si = new SaveInfo();
        //SaveLoadManager.Instance.SavePlayerInfoAsXml(si);
    }

    public void LoadPlayerInfo(int saveSlotNum)
    {
        //GetComponentInChildren<GameObject>();
        GameManager.Instance.PS.Set(SaveLoadManager.Instance.LoadPlayerInfoAsXml<SaveInfo>(saveSlotNum));
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
        ShopManager.Instance.SaveAll();
    }

    public void UseGoButton()
    {
        // 게임 시작
        LoadingSceneManager.LoadScene("GameScene");
    }

}
