using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HCardSelectUI : MonoBehaviour
{
    public HItemSelectManager manager;

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
        manager.CreateRandomItems();

        card1Image.sprite = GetSprite(manager.randomItems[0]);
        card2Image.sprite = GetSprite(manager.randomItems[1]);
        card3Image.sprite = GetSprite(manager.randomItems[2]);

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

            Debug.Log("決定：" + selectIndex);


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

        // 選択中を黄色
        if (selectIndex == 0)
        {
            card1Image.color = selectColor;
        }
        else if (selectIndex == 1)
        {
            card2Image.color = selectColor;
        }
        else if (selectIndex == 2)
        {
            card3Image.color = selectColor;
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