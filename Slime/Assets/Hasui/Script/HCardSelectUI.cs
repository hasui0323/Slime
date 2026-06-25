using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HCardSelectUI : MonoBehaviour
{
    private HItemSelectManager manager;

    public Text card1Text;
    public Text card2Text;
    public Text card3Text;

    public string nextSceneName = "GameScene";

    int selectIndex = 0;

    public Image card1Image;
    public Image card2Image;
    public Image card3Image;

    public Sprite bulletSprite;
    public Sprite hammerSprite;
    public Sprite heartSprite;
    public Sprite heavenSprite;
    public Sprite invinciblSprite;
    public Sprite jumpSprite;
    public Sprite noSkillSprite;
    public Sprite shoesSprite;
    public Sprite timeResetSprite;

    void Start()
    {
        manager = HItemSelectManager.Instance;

        if (manager == null)
        {
            Debug.LogError("HItemSelectManagerが見つかりません");
            return;
        }

        manager.CreateRandomItems();

        card1Image.sprite = GetSprite(manager.randomItems[0]);
        card2Image.sprite = GetSprite(manager.randomItems[1]);
        card3Image.sprite = GetSprite(manager.randomItems[2]);

        card1Text.text = GetDescription(manager.randomItems[0]);
        card2Text.text = GetDescription(manager.randomItems[1]);
        card3Text.text = GetDescription(manager.randomItems[2]);

        UpdateSelect();

        Debug.Log(manager.randomItems[0]);
        Debug.Log(manager.randomItems[1]);
        Debug.Log(manager.randomItems[2]);

    }

    void Update()
    {
        // 左
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectIndex++;

            if (selectIndex > 2)
            {
                selectIndex = 0;
            }

            UpdateSelect();
        }

        // 右
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectIndex--;

            if (selectIndex < 0)
            {
                selectIndex = 2;
            }

            UpdateSelect();
        }

        // Zで決定
        if (Input.GetKeyDown(KeyCode.Z))
        {
            manager.SelectItem(selectIndex);

            Debug.Log("決定アイテム = " +
            manager.selectedItem);

            SceneManager.LoadScene(nextSceneName);
        }
    }

    void UpdateSelect()
    {
        Color32 selectColor = new Color32(0, 90, 150, 255);

        // 全部白
        card1Image.color = Color.white;
        card2Image.color = Color.white;
        card3Image.color = Color.white;

        if (selectIndex == 0)
        {
            card1Image.color = selectColor;
            card1Text.text =
            GetDescription(manager.randomItems[0]);
        }
        else if (selectIndex == 1)
        {
            card2Image.color = selectColor;
            card2Text.text =
           GetDescription(manager.randomItems[1]);
        }
        else if (selectIndex == 2)
        {
            card3Image.color = selectColor;
            card3Text.text =
            GetDescription(manager.randomItems[2]);
        }
    }

    Sprite GetSprite(ItemType item)
    {
        switch (item)
        {
            case ItemType.Bullet:
                return bulletSprite;

            case ItemType.Hammer:
                return hammerSprite;

            case ItemType.Heart:
                return heartSprite;

            case ItemType.Heaven:
                return heavenSprite;

            case ItemType.Invincibl:
                return invinciblSprite;

            case ItemType.Jump:
                return jumpSprite;

            case ItemType.NoSkill:
                return noSkillSprite;

            case ItemType.Shoes:
                return shoesSprite;

            case ItemType.TimeReset:
                return timeResetSprite;

            default:
                return null;
        }
    }

    string GetDescription(ItemType item)
    {
        switch (item)
        {
            case ItemType.Bullet:
                return "敵を倒せる弾を撃つ\n(1回)";

            case ItemType.Hammer:
                return "オブジェクトを破壊できる\n(1回)";

            case ItemType.Heart:
                return "残機が増える\n(1機)";

            case ItemType.Heaven:
                return "天国と地獄\n（スタート時のみ出現・\n天国の場合永続で足が速くなる\n・地獄の場合即死）";

            case ItemType.Invincibl:
                return "敵やダメージオブジェクトに対して無敵\n（オブジェクトをすり抜ける・3秒）";

            case ItemType.Jump:
                return "ハイジャンプができる\n(空中でも使用可能・1回)";

            case ItemType.NoSkill:
                return "スキルなし";

            case ItemType.Shoes:
                return "足が速くなる\n(3秒)";

            case ItemType.TimeReset:
                return "Cキーのダッシュのクールタイムが\n0秒になる(5秒)";

            default:
                return "";
        }
    }

    public void OnCard1()
    {
        manager.SelectItem(0);
    }

    public void OnCard2()
    {
        manager.SelectItem(1);
    }

    public void OnCard3()
    {
        manager.SelectItem(2);
    }
}