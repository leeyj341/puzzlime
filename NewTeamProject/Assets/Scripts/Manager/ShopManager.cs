using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[XmlRoot]
public class BuyCount
{
    [XmlElement]
    public int Count;
    public int CurCount;
    public int Cost;
    
    public bool AddCount(int totalCost)
    {
        if(GameManager.Instance.PS.Gold > totalCost + CalculateCost())
        {
            Cost += CalculateCost();
            CurCount += 1;

            return true;
        }
        return false;
    }

    public bool DelCount()
    {
        if (CurCount == Count) return false;

        CurCount -= 1;
        Cost -= CalculateCost();

        return true;
    }

    private int CalculateCost()
    {
        return 100 * (int)Mathf.Pow(2, CurCount);
    }

    public int SaveCount()
    {
        Count = CurCount;
        return Cost;
    }

    public BuyCount() { Count = 0; CurCount = 0; Cost = 0; }
    public BuyCount(int count, int curcount, int cost) { Count = count; CurCount = curcount; Cost = cost; }
    ~BuyCount() { }
}

public class ShopManager : MonoBehaviour
{
    static public ShopManager Instance = null;
    ShopText m_ShopText;
    public BuyCount CountAtk = new BuyCount();
    public BuyCount CountBullet = new BuyCount();
    public BuyCount CountHealth = new BuyCount();

    public ShopText ST { get => m_ShopText; set => m_ShopText = value; }

    private void Awake()
    {
        if (!Instance) Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int CalculateCost()
    {
        return CountAtk.Cost + CountBullet.Cost + CountHealth.Cost;
    }
    
    public void SaveAll()
    {
        GameManager.Instance.PS.Gold -= (CountAtk.SaveCount() + CountBullet.SaveCount() + CountHealth.SaveCount());
        ST.TextUpdate();
    }
}
