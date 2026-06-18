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

        if (player.hasJump)
        {
            ItemUI.ShowItemInfo("残り " + player.JumpCount + " 回");
        }
        else if (player.hasShoes)
        {
            ItemUI.ShowItemInfo("残り " + SpeedUpTime + " 秒");
        }
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

                ItemUI.ShowItemInfo( "残り " + player.JumpCount + " 回");

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
               
                player.ShoesCount--;

                StartCoroutine(ShoesSpeed());

                if (player.ShoesCount <= 0)
                {
                    player.hasShoes = false;
                    //ItemUI.ClearItem();
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

        player.speed += SpeedUpValue;

        float timer = SpeedUpTime;

        while (timer > 0)
        {
            ItemUI.ShowItemInfo("残り "+
                Mathf.CeilToInt(timer) + " 秒");

            timer -= Time.deltaTime;
            yield return null;
        }

        ItemUI.ShowItemInfo("0 秒");

        yield return new WaitForSeconds(1.0f);

        player.speed -= SpeedUpValue;

        isSpeedUp = false;

        ItemUI.ClearItem();

        if (player.hasShoes)
        {
            ItemUI.ShowItemInfo("残り " + SpeedUpTime + " 秒");
        }
    }

}


