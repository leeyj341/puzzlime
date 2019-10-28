using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BossStatus_Golem : BossState
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void InitBoss()
    {

    }

    protected override void LoadBossData()
    {
#if UNITY_EDITOR
        BossData bossData = AssetDatabase.LoadAssetAtPath<BossData>("Assets/Resources/Data/Boss_Golem.asset");
#else
        BossData bossData = Resources.Load<BossData>("Data/Boss_Golem");
#endif
    }

    public override void Attack()
    {

    }

    public override void Die()
    {
    }

    public override void Move()
    {
    }
}
