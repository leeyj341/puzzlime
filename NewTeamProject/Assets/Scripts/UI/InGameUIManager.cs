using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    public static InGameUIManager Instance;

    public GameObject Weapons;
    public GameObject Items;
    public GameObject Gun;

    // 인벤 커서 관련 변수들 -------------------------------
    public Image WeaponCursor;
    public Image ItemCursor;

    private Vector2 WeaponCursorPos;
    private Vector2 ItemCursorPos;

    private int CurCursorNum = 0;

    // 인벤토리 무기/아이템 관련 변수들 ---------------------
    private List<Image> ImgWeapon = new List<Image>();
    private List<Image> ImgItem = new List<Image>();
    private Image ImgGun;

    private List<Text> TextWeapon = new List<Text>();
    private List<Text> TextItem = new List<Text>();
    private Text TextGun;

    private List<Sprite> SpriteWeapon = new List<Sprite>();
    private List<Sprite> SpriteItem = new List<Sprite>();

    // 기타 텍스트 관련 변수들 ------------------------------
    public Text NumLevel;
    public Text NumGameTime;

    // 플레이어 HP 슬라이더 ---------------------------------

    public Slider HPSlider;

    //-----------------------------------------------------

        

    private void Awake()
    {
        if (!Instance) Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetInventoryUI();

    }

    // Update is called once per frame
    void Update()
    {
        ChangeHpSlider();
        ChangeUIPos();
    }

    private void SetInventoryUI()
    {
        // 커서 초기 위치 저장
        WeaponCursorPos = WeaponCursor.rectTransform.anchoredPosition;
        ItemCursorPos = ItemCursor.rectTransform.anchoredPosition;

        // 인벤토리 아이템/무기 이미지 설정
        ImgWeapon.AddRange(Weapons.GetComponentsInChildren<Image>());
        ImgItem.AddRange(Items.GetComponentsInChildren<Image>());
        ImgGun = Gun.GetComponentInChildren<Image>();

        // 게임 레벨 설정
        NumLevel.text = GameManager.Instance.GameLevel.ToString();
    }

    private void ChangeHpSlider()
    {
        // * 나중에 변경해야 함 -> coroutine 사용, HP가 바뀌는 순간에만 함수 작동되도록
        HPSlider.maxValue = GameManager.Instance.PS.MaxHp;
        HPSlider.value = GameManager.Instance.PS.Hp;

        // 테스트용 
        if (Input.GetKeyDown(KeyCode.J)) GameManager.Instance.PS.Hp--;
        if (Input.GetKeyDown(KeyCode.K)) GameManager.Instance.PS.Hp++;
    }

    public void ChangeGameTime(string sRemaintime)
    {
        NumGameTime.text = sRemaintime;
    }

    public void ChangeCursor(INVEN_MODE curInvenMode)
    {
        switch (curInvenMode)
        {
            case INVEN_MODE.WEAPON:
                if (!WeaponCursor.IsActive())
                    WeaponCursor.gameObject.SetActive(true);
                if (ItemCursor.IsActive())
                    ItemCursor.gameObject.SetActive(false);
                break;
            case INVEN_MODE.USE:
                if (!ItemCursor.IsActive())
                    ItemCursor.gameObject.SetActive(true);
                if (WeaponCursor.IsActive())
                    WeaponCursor.gameObject.SetActive(false);
                break;
        }
    }

    public void MoveCursor(INVEN_MODE curInvenMode, int cursor)
    {
        CurCursorNum = cursor;
        switch (curInvenMode)
        {
            case INVEN_MODE.WEAPON:
                WeaponCursor.rectTransform.anchoredPosition = WeaponCursorPos + new Vector2(GetWidth(true) * cursor, 0);
                break;
            case INVEN_MODE.USE:
                ItemCursor.rectTransform.anchoredPosition = ItemCursorPos + new Vector2(GetWidth(false) * cursor, 0);
                break;
        }
    }

    public void AddImg(INVEN_MODE curInvenMode, string itemName)
    {
        switch (curInvenMode)
        {
            case INVEN_MODE.WEAPON:
                AddSprite(SpriteWeapon, 4, itemName);
                Reorder(ImgWeapon, SpriteWeapon);
                break;
            case INVEN_MODE.USE:
                AddSprite(SpriteItem, 2, itemName);
                Reorder(ImgItem, SpriteItem);
                break;
        }  
    }

    public void AddImg(string GunName)
    {
        ImgGun.sprite = Resources.Load<Sprite>("Image/UI_" + GunName);
        SetImageProperties(ImgGun, Color.white);
    }

    public void DeleteImage(INVEN_MODE curInvenMode, int cursor)
    {
        switch (curInvenMode)
        {
            case INVEN_MODE.WEAPON:
                SpriteWeapon.RemoveAt(cursor);
                Reorder(ImgWeapon, SpriteWeapon);
                break;
            case INVEN_MODE.USE:
                SpriteItem.RemoveAt(cursor);
                Reorder(ImgItem, SpriteItem);
                break;
        }
    }
    
    public void DeleteImage()
    {
        ImgGun.sprite = null;
        SetImageProperties(ImgGun, Color.clear);
    }

    private void AddSprite(List<Sprite> listSprite, int limitCount, string imgName)
    {
        if (listSprite.Count > limitCount) return;
        listSprite.Add(Resources.Load<Sprite>("Image/UI_" + imgName));
    }

    private void Reorder(List<Image> listImg, List<Sprite> listSprite)
    {
        for(int i = 0; i < listImg.Count; i++)
        {
            if (listSprite.Count > i)
            {
                listImg[i].sprite = listSprite[i];
                SetImageProperties(listImg[i], Color.white);
            }
            else
            {
                listImg[i].sprite = null;
                SetImageProperties(listImg[i], Color.clear);
            }

        }
    }

    private void SetImageProperties(Image img, Color color)
    {
        img.color = color;
        img.type = Image.Type.Simple;
        img.preserveAspect = true;
    }

    private float GetWidth(bool isWeapon)
    {
        if (isWeapon)
            return WeaponCursor.rectTransform.rect.width - WeaponCursor.rectTransform.rect.width / 32.0f;
        else
            return ItemCursor.rectTransform.rect.width - ItemCursor.rectTransform.rect.width / 38.0f;
    }

    public void ChangeUIPos()
    {
        WeaponCursor.rectTransform.anchoredPosition = WeaponCursorPos + new Vector2(GetWidth(true) * CurCursorNum, 0);
        ItemCursor.rectTransform.anchoredPosition = ItemCursorPos + new Vector2(GetWidth(false) * CurCursorNum, 0);
        for(int i = 0; i < ImgWeapon.Count; i++)
            ImgWeapon[i].rectTransform.anchoredPosition = new Vector2(WeaponCursorPos.x + GetWidth(true) * i, ImgWeapon[i].rectTransform.anchoredPosition.y);
    }
}
