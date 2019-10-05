using System.Xml.Serialization;

[XmlRoot]
public class SaveInfo
{
    [XmlElement]
    public int WeaponCategory = 0;                                         // 현재 무기 종류

    public string Tag = "";                                                // 현재플레이어 태그
    public int DefaultWeaponNum = 0;                                       // 기본 무기

    public int Stage = 1;                                                  // 현재 스테이지
    public int Gold = 0;                                                   // 소지 현금

    public int AtkCount = 0;
    public int HealthCount = 0;
    public int BulletCount = 0;

    public SaveInfo()
    {
        WeaponCategory = (int)GameManager.Instance.PS.WeaponCategory;
        Tag = GameManager.Instance.PS.Tag;

        DefaultWeaponNum = GameManager.Instance.PS.DefaultWeaponNum;
        Stage = GameManager.Instance.PS.Stage;
        Gold = GameManager.Instance.PS.Gold;

        AtkCount = ShopManager.Instance.CountAtk.Count;
        HealthCount = ShopManager.Instance.CountHealth.Count;
        BulletCount = ShopManager.Instance.CountBullet.Count;
    }
}
