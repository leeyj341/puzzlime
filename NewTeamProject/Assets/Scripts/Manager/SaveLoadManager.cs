using System.Xml.Serialization;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance;

    private void Awake()
    {
        if (!Instance) Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SavePlayerInfoAsBinary<T>(T t, int saveFileNum)
    {
        string path = Path.Combine(Application.dataPath, "Resources/Save/SaveInfo" + saveFileNum + ".bin");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, t);
        stream.Close();
    }

    public T LoadPlayerInfoAsBinary<T>(int saveFileNum)
    {
        string path = Path.Combine(Application.dataPath, "Resources/Save/SaveInfo" + saveFileNum + ".bin");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        T t = (T)formatter.Deserialize(stream);
        stream.Close();

        return t;
    }

    public void SavePlayerInfoAsXml<T>(T t, string saveSlotName)
    {
        string path = Path.Combine(Application.dataPath, "Resources/Save/" + saveSlotName + ".xml");

        XmlSerializer serializer = new XmlSerializer(typeof(T));
        TextWriter writer = new StreamWriter(new FileStream(path, FileMode.Create), Encoding.UTF8);
        serializer.Serialize(writer, t);

        writer.Close();

    }

    public T LoadPlayerInfoAsXml<T>(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        FileStream stream = new FileStream(path, FileMode.Open);
        T t = (T)serializer.Deserialize(stream);
        stream.Close();
        
        return t;
    }
}
