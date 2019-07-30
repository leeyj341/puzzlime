using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    public float BuffForce;
    public BUFF_CATEGORY BuffCtg;
    public float BuffTime;

    public bool Update()
    {
        if (BuffTime <= 0)
            return false; 
        BuffTime -= Time.deltaTime;
        return true;
    }

    public Buff() { }
    ~Buff() { }
}

public class BuffManager : MonoBehaviour
{
    public static BuffManager Instance;
    public List<Buff> ListBuff = new List<Buff>();
    private float m_fBuffAtk;
    private float m_fBuffSpd;

    public float BuffAtk { get => m_fBuffAtk; set => m_fBuffAtk = value; }
    public float BuffSpd { get => m_fBuffSpd; set => m_fBuffSpd = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        if (!BuffManager.Instance) Instance = this;
    }

    private void Start()
    {
        m_fBuffAtk = 0;
        m_fBuffSpd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //List에 담긴 Buff의 업데이트를 수행함
        //버프 지속시간이 종료될 때 버프로 인해 증가된 수치가 삭제되도록 조치해야함
        if (ListBuff.Count.Equals(0)) return;

        for(int i = 0; i < ListBuff.Count; i++)
        {
            if (!ListBuff[i].Update())
                DelBuff(ListBuff[i]);
        }
    }
    //List에 Buff를 삽입하는 함수, 삽입될 때 플레이어에게 증가수치를 전달해줘야함
    public void AddBuff(float BForce, BUFF_CATEGORY BCtg)
    {
        Buff buff = new Buff
        {
            BuffForce = BForce,
            BuffCtg = BCtg,
            BuffTime = 20.0f
        };
        AddBuffToPlayer(buff);
        ListBuff.Add(buff);
    }

    public void DelBuff(Buff buff)
    {
        DelBuffToPlayer(buff);
        ListBuff.Remove(buff);
    }
    
    void AddBuffToPlayer(Buff buff)
    {
        switch (buff.BuffCtg)
        {
            case BUFF_CATEGORY.ATTACK:
                m_fBuffAtk += buff.BuffForce;
                break;
            case BUFF_CATEGORY.SPEED:
                m_fBuffSpd += buff.BuffForce;
                break;
        }
    }

    void DelBuffToPlayer(Buff buff)
    {
        switch (buff.BuffCtg)
        {
            case BUFF_CATEGORY.ATTACK:
                m_fBuffAtk -= buff.BuffForce;
                break;
            case BUFF_CATEGORY.SPEED:
                m_fBuffSpd -= buff.BuffForce;
                break;
        }
    }
}
