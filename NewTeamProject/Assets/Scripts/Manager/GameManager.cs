using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject m_gPlayer;
    PlayerState m_gPlayerState;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!GameManager.Instance)
            Instance = this;
    }

    private void Start()
    {
        m_gPlayerState = m_gPlayer.GetComponent<PlayerState>();
    }

    public GameObject getPlayer()
    {
        return m_gPlayer;
    }
    public PlayerState getPlayerState()
    {
        return m_gPlayerState;
    }
}
