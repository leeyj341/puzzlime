using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public List<RectTransform> rtList = new List<RectTransform>();

    private bool bIsSelected = false;

    private void Update()
    {
        if (GameManager.Instance.PS.DefaultWeaponNum != 0 &&
            GameManager.Instance.PS.tag != "") bIsSelected = true;
    }

    public bool IsSelected()
    {
        return bIsSelected;
    }

    public void SelectWeapon(int weaponNum)
    {
        GameManager.Instance.PS.DefaultWeaponNum = weaponNum;
    }

    public void Select(string tag)
    {
        //캐릭터 선택 정보 전달, scene 전환
        GameManager.Instance.PS.Tag = tag;     
    }

    public void ChangeScaleToOrigin(int CharacterNum)
    {
        StopAllCoroutines();

        if (rtList[CharacterNum].localScale.x.Equals(1.3f)) rtList[CharacterNum].localScale = new Vector3(1.3f, 1.3f, 1);
        else rtList[CharacterNum].localScale = new Vector3(1, 1, 1);
    }

    public void ChangeScale(int CharacterNum)
    {
        StartCoroutine(ChaneImageSize(rtList[CharacterNum]));
    }

    public void FixScale(int CharacterNum)
    {
        for(int i = 0; i < rtList.Count; i++)
        {
            if(i.Equals(CharacterNum))
                rtList[i].localScale = new Vector3(1.3f, 1.3f, 1);
            else rtList[i].localScale = new Vector3(1, 1, 1);
        }
        
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
