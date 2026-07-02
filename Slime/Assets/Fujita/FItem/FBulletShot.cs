using UnityEngine;

public class FBulletShot : MonoBehaviour
{
    FPlayerController player;

    public GameObject bulletPrefab;
    public GameObject hammerPrefab;
    public Transform shotPos;

    public float bulletSpeed = 10.0f;
    public float hammerSpeed = 10.0f;

    public HItemUI ItemUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //同じオブジェクトのPlayerController取得
        player = GetComponent<FPlayerController>();

        ItemUI = FindFirstObjectByType<HItemUI>();

        if (player.hasBullet)
        {
            ItemUI.ShowItemInfo("残り " + player.BulletCount + " 回");
        }
        else if (player.hasHammer)
        {
            ItemUI.ShowItemInfo("残り " + player.HammerCount + " 回");
        }

        Debug.Log(ItemUI);
    }

    // Update is called once per frame
    void Update()
    {
        if (FPlayerController.gameState != "playing")
        {
            return;
        }

        //Bulletアイテムを持っている時だけ撃てる
        if (player.hasBullet)
        {
            //Xキーで発射
            if (Input.GetKeyDown(KeyCode.X))
            {
                ShotBullet();

                player.BulletCount--;
                 
                ItemUI.ShowItemInfo("残り " + player.BulletCount + " 回");

                if (player.BulletCount <= 0)
                {
                    player.hasBullet = false;
                    ItemUI.ClearItem();
                }

                Debug.Log("Shot前");
                Debug.Log(FSoundManager.soundManager);

                //SE再生(Shot)
                FSoundManager.soundManager.SEPlay(SEType.Shot);
                Debug.Log("Shot後");
            }
        }

        //Hammerアイテムを持っている時だけ撃てる
        if (player.hasHammer)
        {
            //Xキーで発射
            if (Input.GetKeyDown(KeyCode.X))
            {
                ShotHammer();

                player.HammerCount--;

                ItemUI.ShowItemInfo("残り " + player.HammerCount + " 回");

                if (player.HammerCount <= 0)
                {
                    player.hasHammer = false;

                    ItemUI.ClearItem();
                }
            }
        }
    }

    //弾を撃つ
    void ShotBullet()
    {
        //弾生成
        GameObject bullet =
            Instantiate(bulletPrefab,
                        shotPos.position,
                        Quaternion.identity);

        //5秒後に消える
        Destroy(bullet, 2.0f);

        //向き判定
        float dir = Mathf.Sign(transform.localScale.x);

        //元のサイズを取得
        Vector3 scale = bullet.transform.localScale;

        //x方向だけ反転
        scale.x = Mathf.Abs(scale.x) * dir;

        //サイズを反映
        bullet.transform.localScale = scale;

        //弾を飛ばす
        Rigidbody2D rbody =
            bullet.GetComponent<Rigidbody2D>();

        //右左に弾を飛ばす用
        rbody.linearVelocity =
            new Vector2(dir * bulletSpeed, 0);
    }

    //ハンマーを撃つ
    void ShotHammer()
    {

        //ハンマー生成
        GameObject hammer =
            Instantiate(hammerPrefab,
                        shotPos.position + new Vector3(0, 0.5f, 0),
                        Quaternion.identity);

        //5秒後に消える
        Destroy(hammer, 2.0f);

        //向き判定
        float dir = Mathf.Sign(transform.localScale.x);

        //元のサイズを取得
        Vector3 scale = hammer.transform.localScale;

        //x方向だけ反転
        scale.x = Mathf.Abs(scale.x) * dir;

        //サイズを反映
        hammer.transform.localScale = scale;

        //弾を飛ばす
        Rigidbody2D rbody =
            hammer.GetComponent<Rigidbody2D>();

        //右左に弾を飛ばす用
        rbody.linearVelocity =
            new Vector2(dir * bulletSpeed, 0);

        //回転させる
        rbody.angularVelocity = -1440;
    }

}
