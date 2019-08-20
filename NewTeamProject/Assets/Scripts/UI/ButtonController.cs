using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void UseStartButton(string nextSceneName)
    {
        GameManager.Instance.PS.Initialize();
        SceneManager.LoadScene(nextSceneName);
        //save
        //SaveInfo si = new SaveInfo();
        //SaveLoadManager.Instance.SavePlayerInfoAsXml(si);
    }

    public void LoadSaveInfo(int saveSlotNum)
    {
        // 예외처리 어떻게 함...?
        GameManager.Instance.PS.Set(SaveLoadManager.Instance.LoadPlayerInfoAsXml<SaveInfo>(saveSlotNum));
        LoadingSceneManager.LoadScene("ShopScene");
    }

    public void UseQuitButton()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

}
