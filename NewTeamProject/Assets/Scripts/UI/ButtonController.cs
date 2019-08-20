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
}
