using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MonsterSpawner : MonoBehaviour
{
    public static MonsterSpawner Instance;

    // 스폰 지역 Vector
    private Dictionary<string, Area> dicArea = new Dictionary<string, Area>();
    // 모든 몬스터 종류를 담은 vector...일지 map일지 모름... 일단 vector...
    private MonsterContainer monsterContainer = new MonsterContainer();

    void Awake()
    {
        if (!Instance) Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnMonster();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomPosition(string areaName)
    {
        float posX = dicArea[areaName].Position.x;
        float posZ = dicArea[areaName].Position.z;
        float distance = dicArea[areaName].MoveDistance;

        float randomX = Random.Range(posX - distance, posX + distance);
        float randomZ = Random.Range(posZ - distance, posZ + distance);

        return new Vector3(randomX, 0.0f, randomZ);
    }

    void SpawnMonster()
    {
        //monsterContainer.Find("고블린");
        GameObject.Find("Enemy").GetComponent<EnemyController>().Area = dicArea["Area1"];
        GameObject.Find("Enemy").transform.position = RandomPosition("Area1");
    }

    public void AddArea(string name, Area area)
    {
        dicArea.Add(name, area);
    }
}
