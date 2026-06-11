using UnityEngine;
using UnityEngine.UI;

public class HHeartUI : MonoBehaviour
{
    public Image[] hearts;

    public Sprite redHeart;
    public Sprite grayHeart;

    public FPlayerController player;

    void Start()
    {
        UpdateHeart();
    }

    void Update()
    {
        UpdateHeart();
    }

    void UpdateHeart()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < player.life)
            {
                hearts[i].sprite = redHeart;
            }
            else
            {
                hearts[i].sprite = grayHeart;
            }
        }
    }
}