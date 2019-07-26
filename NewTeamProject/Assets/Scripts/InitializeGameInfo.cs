using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// GameScene 초기화 클래스
public class InitializeGameInfo : MonoBehaviour
{
    //hint
    public int              nBossTolerance;

    public GameObject[] PrefabHint = new GameObject[4];
    public GameObject[] arrNode = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어 생성
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
        if (GameManager.Instance.Inven) return;

        GameObject player = (GameObject)Instantiate(Resources.Load("PlayerPrefabs/" + GameManager.Instance.PS.Tag), new Vector3(0, 2, 0), Quaternion.identity);
        GameManager.Instance.Inven = player.GetComponent<Inventory>();
        DontDestroyOnLoad(player);
    }
}
