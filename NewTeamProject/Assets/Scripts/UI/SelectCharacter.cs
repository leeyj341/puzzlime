using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public void SelectWeapon(int weaponNum)
    {
        GameManager.Instance.PS.DefaultWeaponNum = weaponNum;
    }

    public void Select(string tag)
    {
        if (GameManager.Instance.PS.DefaultWeaponNum.Equals(0))
        {
            //무기를 선택해주세요! 창 출력
            return;
        }
        //캐릭터 선택 정보 전달, scene 전환
        GameManager.Instance.PS.Tag = tag;
        LoadingSceneManager.LoadScene("ShopScene");       
    }

    public void ChangeScaleToOrigin(RectTransform rt)
    {
        rt.localScale = new Vector3(1, 1, 1);
    }

    public void ChangeScale(RectTransform rt)
    {
        StartCoroutine(ChaneImageSize(rt));
    }

    IEnumerator ChaneImageSize(RectTransform rt)
    {
        while(rt.localScale.x < 1.3f)
        {
            yield return null;

            rt.localScale += new Vector3(0.05f, 0.05f, 0);
        }

        yield return null;
    }
}
