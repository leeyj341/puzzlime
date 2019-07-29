using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float m_fGameTime = Constants.GameTime;
    private int m_nGameLevel = 1;

    private PlayerState m_PS;
    private Inventory m_Inven;

    public Inventory Inven { get => m_Inven; set => m_Inven = value; }
    public PlayerState PS { get => m_PS; set => m_PS = value; }
    public float GameTime { get => m_fGameTime; set => m_fGameTime = value; }
    public int GameLevel { get => m_nGameLevel; set => m_nGameLevel = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        if (!GameManager.Instance)
            Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // GameScene 테스트용
        LoadPlayerState("PlayerState");
    }

    public IEnumerator StartCount(int count)
    {
        yield return null;

        while (count > 0)
        {
            InGameUIManager.Instance.ShowCount(count);
            count--;

            yield return new WaitForSeconds(1.0f);
        }

        InGameUIManager.Instance.TextCount.gameObject.SetActive(false);
        InGameUIManager.Instance.TextStart.gameObject.SetActive(true);

        yield return null;

        // 타이머 시작
        StartCoroutine(ChangeGameTime());
    }

    private IEnumerator ChangeGameTime()
    {
        while (m_fGameTime > 0.0f)
        {
            m_fGameTime -= Time.deltaTime;
            if (m_fGameTime <= 0.0f) m_fGameTime = 0.0f;

            InGameUIManager.Instance.ShowGameTime(ChangeFloatToString(m_fGameTime));

            yield return null;
        }
    }

    private string ChangeFloatToString(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        string sMinutes;
        string sSeconds;

        if (minutes < 10)
            sMinutes = "0" + minutes.ToString();
        else
            sMinutes = minutes.ToString();

        if (seconds < 10)
            sSeconds = "0" + seconds.ToString();
        else
            sSeconds = seconds.ToString();

        return sMinutes + " : " + sSeconds;
    }

    private CURRUNT_SCENE GetCurScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "MainScene":
                return CURRUNT_SCENE.SCENE_MAIN;
            case "SelectScene":
                return CURRUNT_SCENE.SCENE_SELECT;
            case "ShopScene":
                return CURRUNT_SCENE.SCENE_SHOP;
            case "GameScene":
                return CURRUNT_SCENE.SCENE_GAME;
            case "LoadingScene":
                return CURRUNT_SCENE.SCENE_LOADING;
        }
        return 0;
    }

    public void ResetGameTime()
    {
        GameTime = Constants.GameTime;
    }

    public void GameLevelUp()
    {
        m_nGameLevel++;
    }

    public void CreateNewPlayerState(string fileName)
    {
        PS = ScriptableObject.CreateInstance<PlayerState>();
        AssetDatabase.CreateAsset(PS, "Assets/Data/" + fileName + ".asset");
        AssetDatabase.SaveAssets();
    }

    public void LoadPlayerState(string fileName)
    {
        PS = AssetDatabase.LoadAssetAtPath<PlayerState>("Assets/Data/" + fileName + ".asset");
    }
}
