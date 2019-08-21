using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFuntion : MonoBehaviour
{
    public void UseBackButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void UseBuyButton()
    {
        ShopManager.Instance.SaveAll();
    }

    public void UseGoButton(string nextScene)
    {
        LoadingSceneManager.LoadScene(nextScene);
    }

    public void UseGoButton()
    {
        if (gameObject.GetComponent<SelectCharacter>().IsSelected())
            LoadingSceneManager.LoadScene("ShopScene");
    }

}
