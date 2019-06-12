using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameObject m_gPlayer;
    private string m_strPlayerTag = "CowBoy";

    public GameObject Player { get => m_gPlayer; set => m_gPlayer = value; }
    public Inventory Inven { get => m_gPlayer.GetComponent<Inventory>(); }
    public PlayerState PS { get => m_gPlayer.GetComponent<PlayerState>(); }
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

    }
}
