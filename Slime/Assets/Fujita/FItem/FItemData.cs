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
}

public class FItemData : MonoBehaviour
{
    public int value = 0;       //整数値を設定できる
    public ItemType type;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

            //アイテム効果
            if(type==ItemType.Bullet)
            {
                player.hasBullet = true;
            }
        }

        // アイテムを消す
        Destroy(gameObject);
    }
}
