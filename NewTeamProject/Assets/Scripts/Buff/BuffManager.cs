using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class BuffManager : MonoBehaviour
{
    public static BuffManager Instance;
    List<BuffUI> listBuffUI = new List<BuffUI>();
    float buffVerticalDistance = 50.0f;
    public GameObject firstpos;
    Dictionary<BUFF_CATEGORY , Sprite> DictBuffImg = new Dictionary<BUFF_CATEGORY, Sprite>();

    // Start is called before the first frame update
    private void Awake()
    {
        if (!BuffManager.Instance) Instance = this;
        listBuffUI.AddRange(GetComponentsInChildren<BuffUI>());
        for(int i = 0; i < listBuffUI.Count; i++)
        {
            listBuffUI[i].gameObject.SetActive(false);
        }
        AddBuffImage();
    }

    private void AddBuffImage()
    {
        DictBuffImg.Add(BUFF_CATEGORY.ATTACK, AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Resources/Sprite/Power_Buff.png"));
        DictBuffImg.Add(BUFF_CATEGORY.SPEED, AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Resources/Sprite/Speed_Buff.png"));  
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < listBuffUI.Count; i++) 
        {
            if(!listBuffUI[i].isBuffWalk())
            {
                listBuffUI[i].gameObject.SetActive(false);
                BuffUI temp = listBuffUI[i];
                listBuffUI.Remove(temp);
                listBuffUI.Add(temp);
                UpdatePos();
                break;
            }
        }
    }

    void UpdatePos()
    {
        for(int i = 0; i < listBuffUI.Count; i++ )
        {
            listBuffUI[i].gameObject.transform.position = 
                new Vector3(transform.position.x, firstpos.transform.position.y - buffVerticalDistance * i, transform.position.z);
        }
    }

    //List에 Buff를 삽입하는 함수, 삽입될 때 플레이어에게 증가수치를 전달해줘야함
    public void AddBuff(float BForce, BUFF_CATEGORY BCtg)
    {
        for(int i = 0; i < listBuffUI.Count; i++)
        {
            if(listBuffUI[i].BuffCtg == BCtg)
                listBuffUI[i].BuffTime += 20.0f;
                
            else if(listBuffUI[i].BuffCtg == BUFF_CATEGORY.NONE)
            {
                listBuffUI[i].gameObject.SetActive(true);
                listBuffUI[i].BuffTime += 20.0f;
                listBuffUI[i].BuffForce = BForce;
                listBuffUI[i].BuffCtg = BCtg;
                listBuffUI[i].ImgUpdate(DictBuffImg[BCtg]);
                listBuffUI[i].FlashReady();
                UpdatePos();
                return;
            }
        }

    }
}
