using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    public float BuffForce;
    public BUFF_CATEGORI BuffCtg;
    public float BuffTime;

    public bool Update()
    {
        if (BuffTime <= 0)
            return false; 
        //플레이어 버프 증가수치 계산부분
        BuffTime -= Time.deltaTime;
        return true;
    }
}

public class BuffManager : MonoBehaviour
{
    public static BuffManager Instance;
    public List<Buff> ListBuff = new List<Buff>();
    // Start is called before the first frame update
    private void Awake()
    {
        if (!BuffManager.Instance) Instance = this;
    }

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        //List에 담긴 Buff의 업데이트를 수행함
        //버프 지속시간이 종료될 때 버프로 인해 증가된 수치가 삭제되도록 조치해야함
        if (ListBuff.Count == 0) return;

        for(int i = 0; i < ListBuff.Count; i++)
        {
            if(!ListBuff[i].Update())
            {
                //플레이어 버프 증가수치 삭제코드 삽입부분
                ListBuff.Remove(ListBuff[i]);
            }
        }
    }
    //List에 Buff를 삽입하는 함수, 삽입될 때 플레이어에게 증가수치를 전달해줘야함
    public void AddBuff(float BTime, BUFF_CATEGORI BCtg)
    {
        Buff buff = new Buff
        {
            BuffTime = BTime,
            BuffCtg = BCtg
        };

        ListBuff.Add(buff);
    }
}
