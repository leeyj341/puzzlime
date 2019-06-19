using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject m_gPlayer;
    public Inventory m_sInven;
    private PlayerState m_sState;
    private string m_strPlayerTag = "CowBoy";

    public GameObject Player { get => m_gPlayer; set => m_gPlayer = value; }
    public Inventory Inven { get => m_sInven; }
    public PlayerState PS { get => m_sState; }
    public string PlayerTag { get => m_strPlayerTag; set => m_strPlayerTag = value; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (!GameManager.Instance)
            Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        m_sInven = m_gPlayer.GetComponent<Inventory>();
        m_sState = m_gPlayer.GetComponent<PlayerState>();
    }
}
