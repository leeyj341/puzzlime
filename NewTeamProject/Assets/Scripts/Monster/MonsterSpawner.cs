using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MonsterSpawner : MonoBehaviour
{
    public static MonsterSpawner Instance;

    private Dictionary<string, Area> dicArea = new Dictionary<string, Area>();      // 모든 스폰 지역
    private MonsterContainer monsterContainer = new MonsterContainer();             // 모든 몬스터 종류

    void Awake()
    {
        if (!Instance) Instance = this;
        monsterContainer.LoadAllMonsters();
    }

    // Start is called before the first frame update
    void Start()
    {
        // 무작위 스폰...?
        SpawnMonster("Area1", "GoblinWarriorMale");
    }

    Vector3 RandomPosition(string areaName)
    {
        float posX = dicArea[areaName].Position.x;
        float posZ = dicArea[areaName].Position.z;
        float distance = dicArea[areaName].GetPatrolRadius();

        float randomX = Random.Range(posX - distance, posX + distance);
        float randomZ = Random.Range(posZ - distance, posZ + distance);

        return new Vector3(randomX, 2.0f, randomZ);
    }

    void SpawnMonster(string areaName, string prefabName)
    {
        GameObject enemy = Instantiate(Resources.Load("MonsterPrefab/" + prefabName), RandomPosition(areaName), Quaternion.identity) as GameObject;
        enemy.GetComponent<EnemyController>().Status = new MonsterStatus(monsterContainer.Find(prefabName), dicArea[areaName]);
    }

    public void AddArea(string name, Area area)
    {
        dicArea.Add(name, area);
    }
}
