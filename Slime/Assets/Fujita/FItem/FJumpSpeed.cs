using System.Collections;
using UnityEngine;

public class FJumpSpeed : MonoBehaviour
{
    FPlayerController player;
    Rigidbody2D rbody;


    public float JumpPower = 10.0f;//ジャンプのパワー

    public float SpeedUpValue = 3.0f; // 増加量
    public float SpeedUpTime = 8.0f;  // 持続時間

    bool isSpeedUp = false;

    public HItemUI ItemUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<FPlayerController>();
        rbody = GetComponent<Rigidbody2D>();

        ItemUI = FindFirstObjectByType<HItemUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jumpアイテムを持っている時だけ発動できる
        if (player.hasJump)
        {
            //Xキーで発射
            if (Input.GetKeyDown(KeyCode.X))
            {
                JumpSpeed();

                player.JumpCount--;

                if (player.JumpCount <= 0)
                {
                    player.hasJump = false;
                    ItemUI.ClearItem();
                }
            }
        }

        //Shoesアイテムを持っている時だけ発動できる
        if (player.hasShoes)
        {
            //Xキーで発射
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("シューズ発動");
                StartCoroutine(ShoesSpeed());

                player.ShoesCount--;

                if (player.ShoesCount <= 0)
                {
                    player.hasShoes = false;
                    ItemUI.ClearItem();
                }
            }
        }

    }

    void JumpSpeed()
    {
        rbody.linearVelocity =
            new Vector2(rbody.linearVelocity.x, JumpPower);
    }

    IEnumerator ShoesSpeed()
    {
        isSpeedUp = true;

        // 足を速くする
        player.speed += SpeedUpValue;

        // 8秒待つ
        yield return new WaitForSeconds(SpeedUpTime);

        // 元に戻す
        player.speed -= SpeedUpValue;

        isSpeedUp = false;
    }

}


