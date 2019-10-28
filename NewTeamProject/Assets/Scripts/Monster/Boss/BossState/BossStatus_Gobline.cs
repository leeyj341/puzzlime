using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BossStatus_Gobline : BossState
{
    //protected BossData bossdata;
    //protected BOSS_STATE bossState;
    //protected ATK_CATEGORY resistance;
    //protected float stamina;
    //protected float currentHP;
    //protected float staminaRetrieve;
    //protected SkillData[] skill = new SkillData[3];

    // Start is called before the first frame update
    void Start()
    {
        InitBoss();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void InitBoss()
    {
        skill[0] = new Bash();
        skill[1] = new Rush();
        skill[2] = new Rage();

        for (int i = 0; i < skill.Length; i++)
            skill[i].Init();
    }

    protected override void LoadBossData()
    {
#if UNITY_EDITOR
        BossData bossData = AssetDatabase.LoadAssetAtPath<BossData>("Assets/Resources/Data/Boss_Gobline.asset");
#else
        BossData bossData = Resources.Load<BossData>("Data/Boss_Gobline");
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
