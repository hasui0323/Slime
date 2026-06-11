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
    }

    // Update is called once per frame
    void Update()
    {

    }
    //接種
    void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.tag=="Player")
        {
            //プレイヤースクリプトを取得
            FPlayerController player=
                collision.GetComponent<FPlayerController>();

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
                return;
            }

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

            //----------------------------------------------------
        }

        // アイテムを消す
        Destroy(gameObject);
    }
}
