using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBossSpawner : MonoBehaviour
{
    static public StageBossSpawner instance;
    GameObject stageBoss = null;
    BossState bossState = null;


    public GameObject Boss { get => stageBoss; }
    public BossState BossState { get => bossState; }

    private void Awake()
    {
        if (!instance) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
