using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        CreateCharacter();

        StartCoroutine(GameManager.Instance.StartCount(3));
    }

    // Update is called once per frame
    

    private void CreateCharacter()
    {
        if (GameManager.Instance.Inven) return;

        GameObject player = (GameObject)Instantiate(Resources.Load("PlayerPrefabs/" + GameManager.Instance.PS.Tag), new Vector3(0, 2, 0), Quaternion.identity);
        GameManager.Instance.Inven = player.GetComponent<Inventory>();
    }
}
