using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopText : MonoBehaviour
{
    public Text TextAtk_Count;
    public Text TextAtk_CurrentCount;
    public Text TextAtk_Cost;

    public Text TextHealth_Count;
    public Text TextHealth_CurrentCount;
    public Text TextHealth_Cost;

    public Text TextBullet_Count;
    public Text TextBullet_CurrentCount;
    public Text TextBullet_Cost;

    // Start is called before the first frame update
    void Start()
    {
        ShopManager.Instance.ST = this;
        TextUpdate();
    }

    public void TextUpdate()
    {
        TextAtk_Cost.text = ShopManager.Instance.CountAtk.Cost.ToString();
        TextAtk_Count.text = ShopManager.Instance.CountAtk.Count.ToString();
        TextAtk_CurrentCount.text = ShopManager.Instance.CountAtk.CurCount.ToString();

        TextHealth_Cost.text = ShopManager.Instance.CountHealth.Cost.ToString();
        TextHealth_Count.text = ShopManager.Instance.CountHealth.Count.ToString();
        TextHealth_CurrentCount.text = ShopManager.Instance.CountHealth.CurCount.ToString();

        TextBullet_Cost.text = ShopManager.Instance.CountBullet.Cost.ToString();
        TextBullet_Count.text = ShopManager.Instance.CountBullet.Count.ToString();
        TextBullet_CurrentCount.text = ShopManager.Instance.CountBullet.CurCount.ToString();
    }
}
