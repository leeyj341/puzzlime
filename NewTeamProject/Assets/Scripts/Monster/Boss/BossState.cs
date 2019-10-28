using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossState : MonoBehaviour
{
    protected BossData bossdata;
    protected BOSS_STATE bossState;
    protected ATK_CATEGORY resistance;
    protected float stamina;
    protected float currentHP;
    protected float staminaRetrieve;
    protected SkillData[] skill = new SkillData[3];

    public BOSS_STATE State { get => bossState; set => bossState = value; }
    public ATK_CATEGORY Resist { get => resistance; set => resistance = value; }
    public float Stamina { get => stamina; }
    public float CurHP { get => currentHP; }

    protected abstract void InitBoss();
    protected abstract void SkillSetting(int index);
    protected abstract void SkillAction(int index);

    public abstract void Move();
    public abstract void Attack();
    public abstract void Die();
}
