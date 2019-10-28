using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bash : SkillData
{
    //protected float damage;
    //protected float cost;
    //protected bool skillready;
    //protected Gauge castGauge;
    //protected Gauge cooltimeGauge;
    // Start is called before the first frame update
    public override void Init()
    {
        SkillSet(5, 5, 10, 0);
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
