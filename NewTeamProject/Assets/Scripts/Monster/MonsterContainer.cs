using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterContainer
{
    private Dictionary<string, MonsterInfo> dicMonster = new Dictionary<string, MonsterInfo>();
    public Dictionary<string, MonsterInfo> DicMonster { get => dicMonster; set => dicMonster = value; }

    public MonsterContainer()
    {
        // 모든 몬스터 정보 로드
        //LoadMonster("");
    }

    public MonsterInfo Find(string name)
    {
        MonsterInfo monsterInfo;

        if (DicMonster.TryGetValue(name, out monsterInfo))
            return monsterInfo;
        else
            return null;
    }

    private void LoadMonster(string fileName)
    {
#if UNITY_EDITOR
        MonsterInfo monsterInfo = AssetDatabase.LoadAssetAtPath<MonsterInfo>("Assets/Resources/Data/" + fileName + ".asset");
        dicMonster.Add(fileName, monsterInfo);
#else
        MonsterInfo monsterInfo = Resources.Load<MonsterInfo>("Data/" + fileName);
        dicMonster.Add(fileName, monsterInfo);
#endif
    }
}
