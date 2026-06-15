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
        if (HItemSelectManager.Instance != null)
        {
            SetItem(HItemSelectManager.Instance.selectedItem);
        }

        FPlayerController player =
      FindFirstObjectByType<FPlayerController>();

        if (player == null) return;

        if (player.hasBullet)
        {
            ShowItemInfo(player.BulletCount + " âÒ");
        }
        else if (player.hasHammer)
        {
            ShowItemInfo(player.HammerCount + " âÒ");
        }
        else if (player.hasHeart)
        {
            ShowItemInfo( player.HeartCount + " âÒ");
        }
        else if (player.hasHeaven)
        {
            ShowItemInfo(player.HeavenCount + " âÒ");
        }
        else if (player.hasJump)
        {
            ShowItemInfo( player.JumpCount + " âÒ");
        }
        else if (player.hasNoSkill)
        {
            ShowItemInfo(player.NoSkillCount + " âÒ");
        }
        else if (player.hasInvincibl)
        {
            ShowItemInfo(" 8 ïb");
        }
        else if (player.hasShoes)
        {
            ShowItemInfo(" 8 ïb");
        }
        else if (player.hasTimeReset)
        {
            ShowItemInfo(" 10 ïb");
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