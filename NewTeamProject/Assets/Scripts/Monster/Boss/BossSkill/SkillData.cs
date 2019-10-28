using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillData
{
    protected float damage;
    protected float cost;
    protected bool skillready;
    protected Gauge castGauge;
    protected Gauge cooltimeGauge;

    public float Damage { get => damage; set => damage = value; }
    public Gauge CoolTime { get => cooltimeGauge; set => cooltimeGauge = value; }
    public float Cost { get => cost; set => cost = value; }
    public bool SkillReady { get => skillready; set => skillready = value; }
    
    public void SkillSet(float Dmg, float SkillCooltime, float SkillCost, float SkillCastTime)
    {
        damage = Dmg;
        cost = SkillCost;
        
        cooltimeGauge.Init(SkillCooltime);
        castGauge.Init(SkillCastTime);

        skillready = true;
    }
    public abstract void Init();
    public abstract void SkillAction(BossState Boss);
}
