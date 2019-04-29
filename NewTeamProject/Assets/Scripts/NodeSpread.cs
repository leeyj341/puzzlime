using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpread : MonoBehaviour
{
    //hint
    public int              nBossTolerance;

    public GameObject[] PrefabHint = new GameObject[4];
    public GameObject[] arrNode = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        CreatePrefabs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreatePrefabs()
    {
        for(int i = 0; i< arrNode.Length; i++)
        {
            Instantiate(PrefabHint[nBossTolerance], arrNode[i].transform);
        }
    }

}
