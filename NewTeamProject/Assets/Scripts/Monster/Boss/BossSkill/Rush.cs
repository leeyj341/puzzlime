using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush : SkillData
{
    //protected float damage;
    //protected float cost;
    //protected bool skillready;
    //protected Gauge castGauge;
    //protected Gauge cooltimeGauge;
    public override void Init()
    {
        SkillSet(5, 7, 20, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SkillAction(BossState Boss)
    {
        throw new System.NotImplementedException();
    }
}
