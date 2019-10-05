using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveSlot : MonoBehaviour
{
    private Text slotText;
    private SaveInfo si;

    void Awake()
    {
        slotText = GetComponentInChildren<Text>();
        InitSlotText();
    }

    public void LoadSaveInfo()
    {
        if (slotText.text.Equals("EMPTY")) return;

        GameManager.Instance.PS.Set(si);
        ShopManager.Instance.Set(si);
        LoadingSceneManager.LoadScene("ShopScene");

    }

    public void Save()
    {
#if UNITY_EDITOR
        string path = Path.Combine(Application.dataPath, "Resources/Save/" + tag + ".xml");
#else
        string path = Path.Combine(Application.persistentDataPath, tag + ".xml");
#endif
        SaveInfo tempSi = new SaveInfo();
        SaveLoadManager.Instance.SaveAsXml(tempSi, path);
        SetSlotText(tempSi);
    }

    public void InitSlotText()
    {
#if UNITY_EDITOR
        string path = Path.Combine(Application.dataPath, "Resources/Save/" + tag + ".xml");
#else
        string path = Path.Combine(Application.persistentDataPath, tag + ".xml");
#endif
        if (File.Exists(path))
        {
            si = SaveLoadManager.Instance.LoadAsXml<SaveInfo>(path);
            SetSlotText(si);
        }
        else slotText.text = "EMPTY";
    }

    public void SetSlotText(SaveInfo si)
    {
        string stage = "\nSTAGE: " + si.Stage;
        string gold = "  GOLD: " + si.Gold;
        string atk = "  ATK: " + si.AtkCount;
        string health = "  HEALTH: " + si.HealthCount;
        string bullet = "  BULLET: " + si.BulletCount;

        slotText.text = stage + gold + atk + health + bullet;
    }

}
