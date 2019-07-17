using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameObject m_gPlayer = null;
    private string m_strPlayerTag = "CowBoy";
    private float m_fGameTime = 900.0f;
    private string m_sRemainTime = "";
    private int m_nGameLevel = 1;
    public PlayerState PS;
    public WeaponList m_sList;

    public GameObject Player { get => m_gPlayer; set => m_gPlayer = value; }
    public Inventory Inven { get => m_gPlayer.GetComponent<Inventory>(); }
    public WeaponList WL { get => m_sList; set => m_sList = value; }
    public string PlayerTag { get => m_strPlayerTag; set => m_strPlayerTag = value; }
    public float GameTime { get => m_fGameTime; set => m_fGameTime = value; }
    public string RemainTime { get => m_sRemainTime; set => m_sRemainTime = value; }
    public int GameLevel { get => m_nGameLevel; set => m_nGameLevel = value; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (!GameManager.Instance)
            Instance = this;
        DontDestroyOnLoad(gameObject);

        if(!PS)
        {
            PS = ScriptableObject.CreateInstance<PlayerState>();
            AssetDatabase.CreateAsset(PS, "Assets/Data/PlayerState.asset");
            AssetDatabase.SaveAssets();
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (GetCurScene() == CURRUNT_SCENE.SCENE_GAME && m_fGameTime > 0.0f) ChangeGameTime();
    }

    private void ChangeGameTime()
    {
        m_fGameTime = m_fGameTime - Time.deltaTime;

        if (m_fGameTime <= 0.0f) m_fGameTime = 0.0f;

        int minutes = (int)m_fGameTime / 60;
        int seconds = (int)m_fGameTime % 60;
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

        m_sRemainTime = sMinutes + " : " + sSeconds;

        InGameUIManager.Instance.ChangeGameTime(m_sRemainTime);
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

        Debug.Log("활성화된 Scene이 없습니다.");
        return 0;
    }

    public void ResetGameTime(float time)
    {
        GameTime = time;
    }

    public void GameLevelUp()
    {
        m_nGameLevel++;
    }
}
