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
        SaveInfo tempSi = new SaveInfo();
        SaveLoadManager.Instance.SavePlayerInfoAsXml(tempSi, tag);
        SetSlotText(tempSi);
    }

    public void InitSlotText()
    {
        string path = Path.Combine(Application.dataPath, "Resources/Save/" + tag + ".xml");
        if (File.Exists(path))
        {
            si = SaveLoadManager.Instance.LoadPlayerInfoAsXml<SaveInfo>(path);
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
