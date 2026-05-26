using UnityEngine;

public class FBulletShot : MonoBehaviour
{
    FPlayerController player;

    public GameObject bulletPrefab;
    public Transform shotPos;

    public float bulletSpeed = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //同じオブジェクトのPlayerController取得
        player = GetComponent<FPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Bulletアイテムを持っている時だけ撃てる
        if (player.hasBullet)
        {
            //Xキーで発射
            if (Input.GetKeyDown(KeyCode.X))
            {
                Shot();
            }
        }
    }

    //弾を撃つ
    void Shot()
    {
        //弾生成
        GameObject bullet =
            Instantiate(bulletPrefab,
                        shotPos.position,
                        Quaternion.identity);

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
}
