using UnityEngine;
using UnityEngine.UI;

public class HItemUI : MonoBehaviour
{
    public Image itemImage;

    public Sprite defaultSprite;
    public Sprite bulletSprite;
    public Sprite hammerSprite;
    public Sprite heartSprite;
    public Sprite heavenSprite;
    public Sprite invinciblSprite;
    public Sprite jumpSprite;
    public Sprite noSkillSprite;
    public Sprite shoesSprite;
    public Sprite timeResetSprite;

    //効果時間・使用回数表示
    public Text itemInfoText;

    void Start()
    {
        {
            ItemType item =
                HItemSelectManager.Instance.selectedItem;

            SetItem(item);

            switch (item)
            {
                //アイテムの使用回数と効果時間表示
                case ItemType.Bullet:
                    ShowItemInfo("残り 1 回");
                    break;

                case ItemType.Hammer:
                    ShowItemInfo("残り 1 回");
                    break;

                case ItemType.Heart:
                    ShowItemInfo("残り 1 回");
                    break;

                case ItemType.Heaven:
                    ShowItemInfo("残り 1 回");
                    break;

                case ItemType.Invincibl:
                    ShowItemInfo("残り 3 秒");
                    break;

                case ItemType.Jump:
                    ShowItemInfo("残り 1 回");
                    break;

                case ItemType.NoSkill:
                    ShowItemInfo("残り 1 回");
                    break;

                case ItemType.Shoes:
                    ShowItemInfo("残り 3 秒");
                    break;

                case ItemType.TimeReset:
                    ShowItemInfo("残り 5 秒");
                    break;
            }
        }
    }
    public void SetItem(ItemType type)
    {
        switch (type)
        {
            //取得したアイテムに応じてimage変更
            case ItemType.Bullet:
                itemImage.sprite = bulletSprite;
                break;

            case ItemType.Hammer:
                itemImage.sprite = hammerSprite;
                break;

            case ItemType.Heart:
                itemImage.sprite = heartSprite;
                break;

            case ItemType.Heaven:
                itemImage.sprite = heavenSprite;
                break;

            case ItemType.Invincibl:
                itemImage.sprite = invinciblSprite;
                break;

            case ItemType.Jump:
                itemImage.sprite = jumpSprite;
                break;

            case ItemType.NoSkill:
                itemImage.sprite = noSkillSprite;
                break;

            case ItemType.Shoes:
                itemImage.sprite = shoesSprite;
                break;

            case ItemType.TimeReset:
                itemImage.sprite = timeResetSprite;
                break;
        }
    }

    public void ClearItem()
    {
        itemImage.sprite = defaultSprite;
        itemInfoText.text = "";
    }

    public void ShowItemInfo(string info)
    {
        Debug.Log("ShowItemInfo呼び出し : " + info);

        if (itemInfoText == null)
        {
            Debug.LogError("itemInfoText が未設定です");
            return;
        }

        itemInfoText.text = info;
    }
}