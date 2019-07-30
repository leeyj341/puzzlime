using System.Xml;
using UnityEngine;
using UnityEditor;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance;
    private PlayerState m_PS;

    private void Awake()
    {
        if (!Instance) Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_PS = AssetDatabase.LoadAssetAtPath<PlayerState>("Assets/Data/PlayerState.asset");
    }

    public void SaveNewPlayerInfoXml(string saveFileName)
    {
        // 선언부
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        // 노드
        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "PlayerInfo", string.Empty);
        xmlDoc.AppendChild(root);

        XmlNode child = xmlDoc.CreateNode(XmlNodeType.Element, "Player", string.Empty);
        root.AppendChild(child);

        // 속성
        XmlElement hp = xmlDoc.CreateElement("Hp");
        hp.InnerText = m_PS.Hp.ToString();
        child.AppendChild(hp);

        XmlElement maxHp = xmlDoc.CreateElement("MaxHp");
        maxHp.InnerText = m_PS.MaxHp.ToString();
        child.AppendChild(maxHp);

        XmlElement speed = xmlDoc.CreateElement("Speed");
        speed.InnerText = m_PS.Speed.ToString();
        child.AppendChild(speed);

        XmlElement rotSpeed = xmlDoc.CreateElement("RotSpeed");
        rotSpeed.InnerText = m_PS.RotSpeed.ToString();
        child.AppendChild(rotSpeed);

        XmlElement atk = xmlDoc.CreateElement("Atk");
        atk.InnerText = m_PS.Atk.ToString();
        child.AppendChild(atk);

        xmlDoc.Save("./Assets/Resources/Save/" + saveFileName + ".xml");

    }
}
