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

    //å¯â éûä‘ÅEégópâÒêîï\é¶
    public Text itemInfoText;

    void Start()
    {
        {
            ItemType item =
                HItemSelectManager.Instance.selectedItem;

            SetItem(item);

            switch (item)
            {
                case ItemType.Bullet:
                    ShowItemInfo("3 âÒ");
                    break;

                case ItemType.Hammer:
                    ShowItemInfo("1 âÒ");
                    break;

                case ItemType.Heart:
                    ShowItemInfo("1 âÒ");
                    break;

                case ItemType.Heaven:
                    ShowItemInfo("1 âÒ");
                    break;

                case ItemType.Invincibl:
                    ShowItemInfo("3 ïb");
                    break;

                case ItemType.Jump:
                    ShowItemInfo("1 âÒ");
                    break;

                case ItemType.NoSkill:
                    ShowItemInfo("1 âÒ");
                    break;

                case ItemType.Shoes:
                    ShowItemInfo("3 ïb");
                    break;

                case ItemType.TimeReset:
                    ShowItemInfo("10 ïb");
                    break;
            }
        }
    }
    public void SetItem(ItemType type)
    {
        switch (type)
        {
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
        Debug.Log("ShowItemInfoåƒÇ—èoÇµ : " + info);

        if (itemInfoText == null)
        {
            Debug.LogError("itemInfoText Ç™ñ¢ê›íËÇ≈Ç∑");
            return;
        }

        itemInfoText.text = info;
    }
}