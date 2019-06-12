using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIIvenController : MonoBehaviour
{
    public Image WeaponIven;
    public Image ItemIven;
    public Image WeaponCursor;
    public Image ItemCursor;

    private Inventory Inven;

    private float Width = 53.5f;

    private Vector2 WeaponCursorPos;
    private Vector2 ItemCursorPos;

    private List<Image> ImgWeapon = new List<Image>();
    private List<Image> ImgItem = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        SetInventoryImage();

        Inven = GameManager.Instance.GetPlayer().GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        //커서가 바뀔때만 작동하도록 변경해야함
        MoveCursor();
    }

    private void SetInventoryImage()
    {
        //커서 초기 위치 저장
        WeaponCursorPos = WeaponCursor.rectTransform.anchoredPosition;
        ItemCursorPos = ItemCursor.rectTransform.anchoredPosition;

        // 리스트 설정
        ImgWeapon.AddRange(WeaponIven.GetComponentsInChildren<Image>());
        ImgItem.AddRange(ItemIven.GetComponentsInChildren<Image>());

        if (ImgWeapon.Contains(WeaponIven.GetComponent<Image>())) ImgWeapon.RemoveAt(0);
        if (ImgItem.Contains(WeaponIven.GetComponent<Image>())) ImgItem.RemoveAt(0);
    }

    private void MoveCursor()
    {
        WeaponCursor.rectTransform.anchoredPosition = WeaponCursorPos + new Vector2(Width * Inven.CursorWeapon, 0);  
        ItemCursor.rectTransform.anchoredPosition = ItemCursorPos + new Vector2(Width * Inven.CursorUse, 0);
    }
}
