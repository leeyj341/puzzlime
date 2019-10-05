using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ButtonController : MonoBehaviour
{
    public void UseStartButton(string nextSceneName)
    {
        GameManager.Instance.PS.Initialize();
        ShopManager.Instance.Initialize();
        SceneManager.LoadScene(nextSceneName);
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
