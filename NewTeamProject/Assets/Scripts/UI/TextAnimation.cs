using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(SizeUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SizeUp()
    {
        while(text.fontSize < 40)
        {
            text.fontSize += 1;
            text.GetComponentInChildren<Text>().fontSize += 1;
            yield return null;
        }

        StartCoroutine(SizeDown());
    }

    private IEnumerator SizeDown()
    {
        while(text.fontSize > 30)
        {
            text.fontSize -= 1;
            text.GetComponentInChildren<Text>().fontSize -= 1;
            yield return null;
        }

        yield return null;

        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        text.fontSize = 30;
        text.GetComponentInChildren<Text>().fontSize = 30;
    }
}
