using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    public static InGameUIManager Instance;

    public GameObject Weapons;
    public GameObject Items;

    private Inventory Inven;

    // 인벤 커서 관련 변수들 -------------------------------
    public Image WeaponCursor;
    public Image ItemCursor;

    private float Width;

    private Vector2 WeaponCursorPos;
    private Vector2 ItemCursorPos;

    // 인벤토리 무기/아이템 관련 변수들 ---------------------
    private List<Image> ImgWeapon = new List<Image>();
    private List<Image> ImgItem = new List<Image>();

    private List<Text> TextWeapon = new List<Text>();
    private List<Text> TextItem = new List<Text>();

    // 기타 텍스트 관련 변수들 ------------------------------
    public Text NumLevel;
    public Text NumGameTime;
    public Text NumBuffTime;

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
    }

    private void SetInventoryUI()
    {
        //커서 초기 위치 저장
        WeaponCursorPos = WeaponCursor.rectTransform.anchoredPosition;
        ItemCursorPos = ItemCursor.rectTransform.anchoredPosition;

        // 인벤토리 아이템/무기 이미지 설정
        ImgWeapon.AddRange(Weapons.GetComponentsInChildren<Image>());
        ImgItem.AddRange(Items.GetComponentsInChildren<Image>());

        // 인벤 스크립트 설정
        Inven = GameManager.Instance.Player.GetComponent<Inventory>();
    }

    private void ChangeHpSlider()
    {
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
        switch (curInvenMode)
        {
            case INVEN_MODE.WEAPON:
                Width = WeaponCursor.rectTransform.rect.width - WeaponCursor.rectTransform.rect.width / 32.0f;
                WeaponCursor.rectTransform.anchoredPosition = WeaponCursorPos + new Vector2(Width * cursor, 0);
                break;
            case INVEN_MODE.USE:
                Width = ItemCursor.rectTransform.rect.width - ItemCursor.rectTransform.rect.width / 38.0f;
                ItemCursor.rectTransform.anchoredPosition = ItemCursorPos + new Vector2(Width * cursor, 0);
                break;
        }
    }
}
