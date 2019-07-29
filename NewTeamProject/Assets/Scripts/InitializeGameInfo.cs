using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGameInfo : MonoBehaviour
{
    //hint
    public int              nBossTolerance;

    public GameObject[] PrefabHint = new GameObject[4];
    public GameObject[] arrNode = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        CreateHintPrefabs();
        CreateCharacter();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateHintPrefabs()
    {
        for(int i = 0; i< arrNode.Length; i++)
        {
            Instantiate(PrefabHint[nBossTolerance], arrNode[i].transform);
        }
    }

    private void CreateCharacter()
    {
        if (GameManager.Instance.Player) return;
        GameManager.Instance.Player = ((GameObject)Instantiate(Resources.Load("PlayerPrefabs/" + GameManager.Instance.PlayerTag),
            new Vector3(0, 2, 0), Quaternion.identity));
        DontDestroyOnLoad(GameManager.Instance.Player);

        GameManager.Instance.WL = GameObject.Find("RightWeapon").GetComponent<WeaponList>();
        GameManager.Instance.WL.InitForArr();
    }
}
