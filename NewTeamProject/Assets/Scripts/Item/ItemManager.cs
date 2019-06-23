using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    Queue<WeaponScript> m_QueueWeapon = new Queue<WeaponScript>();
    Queue<UseScript> m_QueueUse = new Queue<UseScript>();
    
    public Queue<WeaponScript> Queue_Weapon { get => m_QueueWeapon; }
    public Queue<UseScript> Queue_Use { get => m_QueueUse; }

    private void Awake()
    {
        if (!ItemManager.Instance) Instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 50; i++)
        {
            m_QueueWeapon.Enqueue(new WeaponScript());
            m_QueueUse.Enqueue(new UseScript());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public WeaponScript MakeWeapon(short num, ATK_CATEGORY ctg)
    {
        m_QueueWeapon.Peek().SetItemObtion(num, ctg);
        return m_QueueWeapon.Dequeue();
    }

    public UseScript MakeUse(short num)
    {
        m_QueueUse.Peek().SetItemObtion(num);
        return m_QueueUse.Dequeue();
    }

    public bool ActiveWeaponItem(WeaponScript Weapon)
    {
        if (Weapon.Dbl == -1) return false;

        Weapon.Dbl--;
        if (Weapon.Dbl == 0)
            return true;

        return false;
    }

    public bool ActiveUseItem(UseScript use)
    {
        bool Work = true;
        switch (use.UseCtg)
        {
            case USE_CATEGORY.BULLET:
                if (!GameManager.Instance.Inven.SubWeapon)
                    return Work = false;
                GameManager.Instance.Inven.SubWeapon.Dbl =
                    GameManager.Instance.Inven.SubWeapon.Dbl + GameManager.Instance.Inven.SubWeapon.MaxDbl / 3;
                break;
            case USE_CATEGORY.HEALTHPOTION:
                if (GameManager.Instance.PS.MaxHp > GameManager.Instance.PS.Hp)
                    GameManager.Instance.PS.Hp += 3;

                if (GameManager.Instance.PS.MaxHp < GameManager.Instance.PS.Hp)
                    GameManager.Instance.PS.Hp = GameManager.Instance.PS.MaxHp;
                break;
            case USE_CATEGORY.POWERPOTION:
                BuffManager.Instance.AddBuff(use.Power, BUFF_CATEGORY.ATTACK);
                break;
            case USE_CATEGORY.SPEEDPOTION:
                BuffManager.Instance.AddBuff(use.Power, BUFF_CATEGORY.SPEED);
                break;
        }

        return Work;
    }
}
