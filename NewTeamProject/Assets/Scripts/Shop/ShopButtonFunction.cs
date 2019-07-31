using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonFunction : MonoBehaviour
{
    public void AtkUp()
    {
        if (ShopManager.Instance.CountAtk.AddCount(ShopManager.Instance.CalculateCost()))
        {
            ShopManager.Instance.ST.TextAtk_Cost.text = ShopManager.Instance.CountAtk.Cost.ToString();
            ShopManager.Instance.ST.TextAtk_CurrentCount.text = ShopManager.Instance.CountAtk.CurCount.ToString();
        }
    }

    public void HealthUp()
    {
        if (ShopManager.Instance.CountHealth.AddCount(ShopManager.Instance.CalculateCost()))
        {
            ShopManager.Instance.ST.TextHealth_Cost.text = ShopManager.Instance.CountHealth.Cost.ToString();
            ShopManager.Instance.ST.TextHealth_CurrentCount.text = ShopManager.Instance.CountHealth.CurCount.ToString();
        }
    }

    public void BulletUp()
    {
        if (ShopManager.Instance.CountBullet.AddCount(ShopManager.Instance.CalculateCost()))
        {
            ShopManager.Instance.ST.TextBullet_Cost.text = ShopManager.Instance.CountBullet.Cost.ToString();
            ShopManager.Instance.ST.TextBullet_CurrentCount.text = ShopManager.Instance.CountBullet.CurCount.ToString();
        }
    }

    public void AtkDown()
    {
        if (ShopManager.Instance.CountAtk.DelCount())
        {
            ShopManager.Instance.ST.TextAtk_Cost.text = ShopManager.Instance.CountAtk.Cost.ToString();
            ShopManager.Instance.ST.TextAtk_CurrentCount.text = ShopManager.Instance.CountAtk.CurCount.ToString();
        }
    }

    public void HealthDown()
    {
        if (ShopManager.Instance.CountHealth.DelCount())
        {
            ShopManager.Instance.ST.TextHealth_Cost.text = ShopManager.Instance.CountHealth.Cost.ToString();
            ShopManager.Instance.ST.TextHealth_CurrentCount.text = ShopManager.Instance.CountHealth.CurCount.ToString();
        }
    }

    public void BulletDown()
    {
        if (ShopManager.Instance.CountBullet.DelCount())
        {
            ShopManager.Instance.ST.TextBullet_Cost.text = ShopManager.Instance.CountBullet.Cost.ToString();
            ShopManager.Instance.ST.TextBullet_CurrentCount.text = ShopManager.Instance.CountBullet.CurCount.ToString();
        }
    }
}
