using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
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
    }
}