using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MonsterSpawner : MonoBehaviour
{
    public static MonsterSpawner Instance;

    private Dictionary<string, Area> dicArea = new Dictionary<string, Area>();      // 모든 스폰 지역
    private MonsterContainer monsterContainer = new MonsterContainer();             // 모든 몬스터 종류

    private List<GameObject> listMonsterPool = new List<GameObject>();

    void Awake()
    {
        if (!Instance) Instance = this;
        monsterContainer.LoadAllMonsters();
    }

    // Start is called before the first frame update
    void Start()
    {
        // 포털에서 스폰후 지역 찾아감.
        SpawnMonster("Area1", "고블린남자");
    }

    void SpawnMonster(string areaName, string prefabName)
    {
        Vector3 spawnPos = dicArea[areaName].ListPortal[Random.Range(1, 3)].position;
        spawnPos.y = 2.0f;

        GameObject enemy = Instantiate(Resources.Load("MonsterPrefab/" + prefabName), spawnPos, Quaternion.identity, transform) as GameObject;
        enemy.GetComponent<EnemyController>().Status = new MonsterStatus(monsterContainer.Find(prefabName), dicArea[areaName]);

        // 첫 스폰 후 풀에 등록
        listMonsterPool.Add(enemy);
    }

    void RespawnMonster()
    {
        // 어떤 방식으로 재생성 할지 상의 후 작성
    }

    public void AddArea(string name, Area area)
    {
        dicArea.Add(name, area);
    }
}
