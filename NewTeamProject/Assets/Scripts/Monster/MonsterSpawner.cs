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
        Spawn();
        //StartCoroutine(RespawnMonster());
    }

    void Spawn()
    {
        for(int i = 0; i < 1; i++)
        {
            if(i < 25)
                SpawnMonster("Area1", "고블린남자궁수");
            else if(i < 50)
                SpawnMonster("Area2", GetRandomMonster());
            else if(i < 75)
                SpawnMonster("Area3", GetRandomMonster());
            else
                SpawnMonster("Area4", GetRandomMonster());
        }
    }

    void SpawnMonster(string areaName, string prefabName)
    {
        Vector3 spawnPos = dicArea[areaName].ListPortal[Random.Range(1, 3)].position;
        spawnPos.y = 2.0f;

        GameObject enemy = Instantiate(Resources.Load("MonsterPrefab/" + prefabName), spawnPos, Quaternion.identity, dicArea[areaName].transform) as GameObject;
        enemy.GetComponent<EnemyController>().Status = new MonsterStatus(monsterContainer.Find(prefabName), dicArea[areaName]);

        // 첫 스폰 후 풀에 등록
        listMonsterPool.Add(enemy);
    }

    string GetRandomMonster()
    {
        int num = Random.Range(0, 4);

        switch (num)
        {
            case 0:
                return "고블린여자";
            case 1:
                return "고블린남자";
            case 2:
                return "고블린여자궁수";
            case 3:
                return "고블린남자궁수";
        }

        return null;
    }

    IEnumerator RespawnMonster()
    {
        yield return new WaitForSeconds(20.0f);

        for (int i = 0; i < listMonsterPool.Count; i++)
        {
            if (listMonsterPool[i].activeInHierarchy) continue;
            else
                listMonsterPool[i].SetActive(true);  
            // 코루틴을... 어떻게 재시작을.... 할 것인가..
        }

        StopAllCoroutines();
        StartCoroutine(RespawnMonster());
    }

    public void AddArea(string name, Area area)
    {
        dicArea.Add(name, area);
    }
}
