using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterContainer
{
    private Dictionary<string, MonsterInfo> dicMonster = new Dictionary<string, MonsterInfo>();
    public Dictionary<string, MonsterInfo> DicMonster { get => dicMonster; set => dicMonster = value; }

    public MonsterInfo Find(string name)
    {
        MonsterInfo monsterInfo;

        if (DicMonster.TryGetValue(name, out monsterInfo))
            return monsterInfo;
        else
            return null;
    }

    public void LoadAllMonsters()
    {
        // 모든 몬스터 정보 로드
        LoadMonster("Goblin_Male");
        LoadMonster("Goblin_Female");
        LoadMonster("Goblin_Ranged_Male");
        LoadMonster("Goblin_Ranged_Female");
    }

    private void LoadMonster(string fileName)
    {
#if UNITY_EDITOR
        MonsterInfo monsterInfo = AssetDatabase.LoadAssetAtPath<MonsterInfo>("Assets/Resources/Data/" + fileName + ".asset");
        dicMonster.Add(monsterInfo.PrefabName, monsterInfo);
#else
        MonsterInfo monsterInfo = Resources.Load<MonsterInfo>("Data/" + fileName);
        dicMonster.Add(fileName, monsterInfo);
#endif
    }
}
