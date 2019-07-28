using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;
    private Slider progressBar;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        progressBar = GetComponent<Slider>();

        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float fTime = 0.0f;

        while (!op.isDone)
        {
            yield return null;

            fTime += Time.deltaTime;

            if(op.progress >= 0.9f)
            {
                progressBar.value = Mathf.Lerp(progressBar.value, 1.0f, fTime);

                if (progressBar.value == 1.0f)
                    op.allowSceneActivation = true;
            }
            else
            {
                progressBar.value = Mathf.Lerp(progressBar.value, op.progress, fTime);

                if (progressBar.value >= op.progress)
                    fTime = 0.0f;
            }
        }
    }
}
