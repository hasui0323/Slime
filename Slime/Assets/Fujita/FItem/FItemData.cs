using NUnit.Framework.Internal;
using UnityEngine;

//アイテムの種類
public enum ItemType
{
    Bullet,
    Hammer,
    Heart,
    Heaven,
    Invincibl,
    Jump,
    NoSkill,
    Shoes,
    TimeReset,

    RandomCard,
}

public class FItemData : MonoBehaviour
{
    public int value = 0;       //整数値を設定できる
    public ItemType type;

    //ItemUI用
    HItemUI ItemUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ItemUI = FindFirstObjectByType<HItemUI>();

        Debug.Log(ItemUI);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //接種
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("アイテムに接触");
        if (collision.gameObject.tag=="Player")
        {
            Debug.Log("Player接触");
            //プレイヤースクリプトを取得
            FPlayerController player=
                collision.GetComponent<FPlayerController>();

            Debug.Log(player);

            if (player == null)
            {
                Debug.LogError("FPlayerControllerが取得できていません");
                return;
            }

            // 何かアイテムを持っていたら取得不可
            if (player.hasBullet ||
                player.hasHammer ||
                player.hasHeart ||
                player.hasHeaven ||
                player.hasInvincibl ||
                player.hasJump ||
                player.hasNoSkill ||
                player.hasShoes ||
                player.hasTimeReset)
            {
                Debug.Log("既にアイテム所持中");
                return;
            }
            Debug.Log("所持チェック通過");

            //アイテム効果--------------------------------------------------
            //ランダム
            if (type == ItemType.RandomCard)
            {
                ItemType[] items =
                {
                    ItemType.Bullet,
                    ItemType.Hammer,
                    ItemType.Heart,
                    ItemType.Invincibl,
                    ItemType.Jump,
                    ItemType.NoSkill,
                    ItemType.Shoes,
                    ItemType.TimeReset
                 };

                ItemType randomItem =
                    items[Random.Range(0, items.Length)];

                player.GiveItem(randomItem);

                ItemUI.SetItem(randomItem);

                if (randomItem == ItemType.Bullet)
                {
                    ItemUI.ShowItemInfo(" 3 回");
                }
                else if (randomItem == ItemType.Hammer)
                {
                    ItemUI.ShowItemInfo(" 1 回");
                }
                else if (randomItem == ItemType.Heart)
                {
                    ItemUI.ShowItemInfo(" 1 回");
                }
                else if (randomItem == ItemType.Invincibl)
                {
                    ItemUI.ShowItemInfo(" 3 秒");
                }
                else if (randomItem == ItemType.Jump)
                {
                    ItemUI.ShowItemInfo(" 1 回");
                }
                else if (randomItem == ItemType.NoSkill)
                {
                    ItemUI.ShowItemInfo(" 1 回");
                }
                else if (randomItem == ItemType.Shoes)
                {
                    ItemUI.ShowItemInfo(" 3 秒");
                }
                else if (randomItem == ItemType.TimeReset)
                {
                    ItemUI.ShowItemInfo(" 10 秒");
                }

                Debug.Log("ランダム取得：" + randomItem);

                Destroy(gameObject);
                return;
            }
            //弾
            if (type==ItemType.Bullet)
            {
                player.hasBullet = true;
                player.BulletCount = 3;
            }
            //ハンマー
            if (type == ItemType.Hammer)
            {
                player.hasHammer = true;
                player.HammerCount = 1;
            }

            if (type == ItemType.Heart)
            {
                player.hasHeart = true;
                player.HeartCount = 1;
            }

            if (type == ItemType.Heaven)
            {
                player.hasHeaven = true;
                player.HeavenCount = 1;
            }

            if (type == ItemType.Invincibl)
            {
                player.hasInvincibl = true;
                player.InvinciblCount = 1;
            }

            if (type == ItemType.Jump)
            {
                player.hasJump = true;
                player.JumpCount = 1;
            }

            if (type == ItemType.NoSkill)
            {
                player.hasNoSkill = true;
                player.NoSkillCount = 1;
            }
            
            if (type == ItemType.Shoes)
            {
                player.hasShoes = true;
                player.ShoesCount = 1;
            }

            if (type == ItemType.TimeReset)
            {
                player.hasTimeReset = true;
                player.TimeResetCount = 1;
            }

            ItemUI.SetItem(type);

            if (type == ItemType.Bullet)
            {
                ItemUI.ShowItemInfo("残り " + player.BulletCount + " 回");
            }
            else if (type == ItemType.Hammer)
            {
                ItemUI.ShowItemInfo("残り " + player.HammerCount + " 回");
            }
            else if (type == ItemType.Heart)
            {
                ItemUI.ShowItemInfo("残り " + player.HeartCount + " 回");
            }
            else if (type == ItemType.Heaven)
            {
                ItemUI.ShowItemInfo("残り " + player.HeavenCount + " 回");
            }
            else if (type == ItemType.Jump)
            {
                ItemUI.ShowItemInfo("残り " + player.JumpCount + " 回");
            }
            else if (type == ItemType.NoSkill)
            {
                ItemUI.ShowItemInfo("残り " + player.NoSkillCount + " 回");
            }
            else if (type == ItemType.Invincibl)
            {
                ItemUI.ShowItemInfo("効果時間 8 秒");
            }
            else if (type == ItemType.Shoes)
            {
                ItemUI.ShowItemInfo("効果時間 8 秒");
            }
            else if (type == ItemType.TimeReset)
            {
                ItemUI.ShowItemInfo("効果時間 10 秒");
            }

            //----------------------------------------------------
            // アイテムを消す
            Destroy(gameObject);
        }

        //// アイテムを消す
        //Destroy(gameObject);
    }
}
