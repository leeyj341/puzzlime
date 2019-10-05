using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff
{
    public float BuffForce;
    public BUFF_CATEGORY BuffCtg;
    public float BuffTime;
    
    public bool isBuffWalk()
    {
        if (BuffTime <= 0)
        {
            BuffTime = 0;
            return false;
        } 
        BuffTime -= Time.deltaTime;
        return true;
    }

    public Buff() { BuffTime = 0; BuffForce = 0; }
    ~Buff() { }
}

public class BuffManager : MonoBehaviour
{
    public static BuffManager Instance;
    private float m_fBuffAtk;
    private float m_fBuffSpd;

    public Image ImgBuffAtk;
    public Text TextBuffAtk;

    public Image ImgBuffSpd;
    public Text TextBuffSpd;

    Buff m_cAtkBuff = new Buff();
    Buff m_cSpdBuff = new Buff();

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

        m_cAtkBuff.BuffCtg = BUFF_CATEGORY.ATTACK;
        m_cSpdBuff.BuffCtg = BUFF_CATEGORY.SPEED;
    }

    // Update is called once per frame
    void Update()
    {
        AtkTextUpdate();
        SpdTextUpdate();
    }
    //List에 Buff를 삽입하는 함수, 삽입될 때 플레이어에게 증가수치를 전달해줘야함
    public void AddBuff(float BForce, BUFF_CATEGORY BCtg)
    {
        if(BCtg == BUFF_CATEGORY.ATTACK)
        {
            m_cAtkBuff.BuffTime += 20.0f;
            if (m_cAtkBuff.BuffTime > 60.0f)
                m_cAtkBuff.BuffTime = 60.0f;
            m_cAtkBuff.BuffForce = BForce;
        }

        else
        {
            m_cSpdBuff.BuffTime += 20.0f;
            if (m_cSpdBuff.BuffTime > 60.0f)
                m_cSpdBuff.BuffTime = 60.0f;
            m_cSpdBuff.BuffForce = BForce;
        }
    }

    void AtkTextUpdate()
    {
        if (!m_cAtkBuff.isBuffWalk())
        { 
            TextBuffAtk.text = "Off";
            m_fBuffAtk = 0;
        }
        else
        {
            int TextCount = (int)m_cAtkBuff.BuffTime;
            TextBuffAtk.text = TextCount.ToString();
            m_fBuffAtk = m_cAtkBuff.BuffForce;
        }
    }

    void SpdTextUpdate()
    {
        if (!m_cSpdBuff.isBuffWalk())
        {
            TextBuffSpd.text = "Off";
            m_fBuffSpd = 0;
        }
        else
        {
            int TextCount = (int)m_cSpdBuff.BuffTime;
            TextBuffSpd.text = TextCount.ToString();
            m_fBuffSpd = m_cSpdBuff.BuffForce;
        }
    }
}
