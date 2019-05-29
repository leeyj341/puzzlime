using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameObject m_gPlayer;
    PlayerState m_gPlayerState;

    private string m_strPlayerTag = "CowBoy";
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (!GameManager.Instance)
            Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
    }
    

    public void SetTag(string tag)
    {
        m_strPlayerTag = tag;
    }
    
    public string GetTag()
    {
        return m_strPlayerTag;
    }

    public void SetPlayer(GameObject player)
    {
        m_gPlayer = player;
    }

    public GameObject GetPlayer()
    {
        return m_gPlayer;
    }
    public PlayerState GetPlayerState()
    {
        return m_gPlayerState;
    }
}
