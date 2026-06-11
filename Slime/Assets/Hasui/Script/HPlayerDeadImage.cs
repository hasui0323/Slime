using UnityEngine;
using UnityEngine.UI;

public class HPlayerDeadImage : MonoBehaviour
{
    // Ø‚è‘Ö‚¦‚½‚¢Image
    public Image targetImage;

    // ’Êí‚Ì‰æ‘œ
    public Sprite normalSprite;

    // Dead‚Ì‰æ‘œ
    public Sprite deadSprite;

    private void Start()
    {
        // Å‰‚Í’Êí‰æ‘œ
        targetImage.sprite = normalSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ‘Šè‚Ìƒ^ƒO‚ªDead‚È‚ç‰æ‘œ•ÏX
        if (collision.CompareTag("Enemy"))
        {
            targetImage.sprite = deadSprite;
        }
    }
}
