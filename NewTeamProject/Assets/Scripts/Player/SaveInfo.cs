using System.Xml.Serialization;

[XmlRoot]
public class SaveInfo
{
    private int weaponCategory = 0;                                         // 현재 무기 종류

    private string tag = "";                                                // 현재플레이어 태그
    private int defaultWeaponNum = 0;                                       // 기본 무기

    private int stage = 1;                                                  // 현재 스테이지
    private int gold = 0;                                                   // 소지 현금

    private int atkCount = 0;
    private int healthCount = 0;
    private int bulletCount = 0;

    [XmlElement]
    public int WeaponCategory { get => weaponCategory; set => weaponCategory = value; }

    public string Tag { get => tag; set => tag = value; }                                            
    public int DefaultWeaponNum { get => defaultWeaponNum; set => defaultWeaponNum = value; }

    public int Stage { get => stage; set => stage = value; }
    public int Gold { get => gold; set => gold = value; }

    public int AtkCount { get => atkCount; set => atkCount = value; }
    public int HealthCount { get => healthCount; set => healthCount = value; }
    public int BulletCount { get => bulletCount; set => bulletCount = value; }

    public SaveInfo()
    {
        weaponCategory = (int)GameManager.Instance.PS.WeaponCategory;
        tag = GameManager.Instance.PS.Tag;

        defaultWeaponNum = GameManager.Instance.PS.DefaultWeaponNum;
        stage = GameManager.Instance.PS.Stage;
        gold = GameManager.Instance.PS.Gold;

        atkCount = ShopManager.Instance.CountAtk.Count;
        healthCount = ShopManager.Instance.CountHealth.Count;
        bulletCount = ShopManager.Instance.CountBullet.Count;
    }
}
