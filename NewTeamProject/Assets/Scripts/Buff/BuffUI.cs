using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffUI : MonoBehaviour
{
    public Image buffImage;
    public Text buffText;
    
    bool flashSet = false;
    float flashTime = 0.0f;

    BUFF_CATEGORY buffCtg = BUFF_CATEGORY.NONE;
    float buffForce = 0;
    float buffTime = 0;

    public BUFF_CATEGORY BuffCtg { get => buffCtg; set => buffCtg = value; }
    public float BuffForce { get => buffForce; set => buffForce = value; }
    public float BuffTime { get => buffTime; set => buffTime = value; }

    // Start is called before the first frame update
    void Start()
    {
        FlashReady();
    }

    // Update is called once per frame
    void Update()
    {
        BuffFlash();
    }

    public void ImgUpdate(Sprite img)
    {
        buffImage.sprite = img;
    }

    public void FlashReady()
    {
        flashSet = false;
        buffImage.color = new Color(1, 1, 1, 1);
    }

    void BuffFlash()
    {
        if (buffTime <= 5.0f)
        {
            if (!flashSet)
            {
                flashSet = true;
                flashTime = buffTime * 0.2f;
                if (buffImage.color.a >= 0.9) buffImage.color = new Color(1, 1, 1, 0.3f);
                else buffImage.color = new Color(1, 1, 1, 1);
            }
            else
            {
                flashTime -= Time.deltaTime;
                if (flashTime <= 0)
                    flashSet = false;
            }
        }
    }

    void TextUpdate()
    {
        buffText.text = ((int)buffTime).ToString();
    }

    public bool isBuffWalk()
    {
        if (buffCtg == BUFF_CATEGORY.NONE) return true;
        TextUpdate();
        if (BuffTime <= 0)
        {
            BuffTime = 0;
            buffCtg = BUFF_CATEGORY.NONE;
            return false;
        }
        BuffTime -= Time.deltaTime;
        return true;
    }
}
