using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData
{
    private float damage;
    private float coolTime;
    private float curCoolTime;
    private float cost;
    private bool skillready;

    public float Damage { get => damage; set => damage = value; }
    public float CoolTime { get => coolTime; set => coolTime = value; }
    public float Cost { get => cost; set => cost = value; }
    public float CurrentCoolTime { get => curCoolTime; }
    public bool SkillReady { get => skillready; set => skillready = value; }
    
    public void SkillSet(float Dmg, float Ctm, float Cst) { damage = Dmg; coolTime = Ctm; cost = Cst; }
}
