using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumScripts : MonoBehaviour
{
    public static List<string> CharacterList = new List<string>();

    public static void CreateCharacterList()
    {
        CharacterList.Add("CowBoy");
        CharacterList.Add("CowGirl");
    }
}

