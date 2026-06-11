using UnityEngine;
using static UnityEditor.Progress;

public class FPlayerController : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D型の変数
    float axisH = 0.0f;             //入力
    public float speed = 3.0f;      //移動速度

    public float jump = 9.0f;       //ジャンプ力
    public LayerMask groundLayer;   //着地できるレイヤー
    bool goJump = false;            //ジャンプ開始フラグ

    public float dashPower = 20f;   //ダッシュの強さ
    bool isDashing = false;
    bool canDash = true;            //ダッシュ可能か
    public float dashCoolTime = 0.5f; //クールタイム(秒)
    public float normalDashCoolTime = 0.5f;

    public int life = 1;            //プレイヤーの体力
    public bool isInvincible = false;   //プレイヤー無敵中

    public bool isTimeReset = false;    //プレイヤーダッシュのクールタイムなし中

    // アイテム能力--------------------------------------------
    public bool hasBullet = false;
    public bool hasHammer = false;
    public bool hasHeart = false;
    public bool hasHeaven = false;
    public bool hasInvincibl = false;
    public bool hasJump = false;
    public bool hasNoSkill = false;
    public bool hasShoes = false;
    public bool hasTimeReset = false;

    //アイテム回数--------------------------------------------
    public int BulletCount = 0;
    public int HammerCount = 0;
    public int HeartCount = 0;
    public int HeavenCount = 0;
    public int InvinciblCount = 0;
    public int JumpCount = 0;
    public int NoSkillCount = 0;
    public int ShoesCount = 0;
    public int TimeResetCount = 0;

    //------------------------------------------------

    //アニメーション対応
    Animator animator;     //アニメーター
    public string stopAnime = "FPlayerStop";
    public string moveAnime = "FPlayerMove";
    public string jumpAnime = "FPlayerJump";
    public string goalAnime = "FPlayerGoal";
    public string deadAnime = "FPlayerOver";
    public string nowAnime = "";
    public string oldAnime = "";
    public string dashAnime = "FPlayerDash";

    public static string gameState = "playing";//ゲームの状態

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();     //Rigidbody2Dを取ってくる
        animator = GetComponent<Animator>();        //Animatorを取ってくる
        nowAnime = stopAnime;                       //停止から開始する
        oldAnime = stopAnime;                       //停止から開始する

        gameState = "playing";   //ゲーム中にする

        if (HItemSelectManager.Instance != null)
        {
            GiveItem(HItemSelectManager.Instance.selectedItem);

            ItemType item = HItemSelectManager.Instance.selectedItem;


            GiveItem(item);

            // UI更新
            HItemUI itemUI = FindFirstObjectByType<HItemUI>();

            if (itemUI != null)
            {
                itemUI.SetItem(item);
            }

            Debug.Log(
                "引き継いだアイテム：" +
                HItemSelectManager.Instance.selectedItem);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState!="playing")
        {
            return;
        }

        //------------------------------------------------
        //水平方向の入力をチェックする
        axisH = Input.GetAxisRaw("Horizontal");
        //向きの調整
        if(axisH > 0.0f)
        {
            //右移動
            Debug.Log("右移動");
            transform.localScale = new Vector2(0.15f, 0.15f);
        }
        else if(axisH<0.0f)
        {
            //左移動
            Debug.Log("左移動");
            transform.localScale= new Vector2(-0.15f, 0.15f);   //左右反転させる
        }

        //キャラクターをジャンプさせる
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.C) && canDash)
        {
            Dash();

            Debug.Log("aaa");
        }

        //アイテム所持時の動き--------------------------------------------------------

        // 弾アイテムを持っている時
        if (hasBullet)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("弾を撃つ！");
            }
        }
        //ハンマーアイテムを持っている時
        if (hasHammer)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("弾を撃つ！");
            }
        }

    }
    //--------------------------------------------------------------------------------

    void FixedUpdate()
    {
        if(gameState!="playing")
        {
            return;
        }

        //地上判定
        bool onGround = Physics2D.CircleCast(transform.position,    //発射位置
                                            0.2f,                   //円の半径
                                            Vector2.down,           //発射方向
                                            0.2f,                   //発射距離
                                            groundLayer);           //検出するレイヤー

        Debug.Log(onGround);

        ////プレイヤーの横の速さを変えている
        //rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);

        if (!isDashing)
        {
            rbody.linearVelocity =
                new Vector2(axisH * speed, rbody.linearVelocity.y);
        }

        if (onGround&&goJump)
        {
            //地面でジャンプキーが押された
            //ジャンプさせる
            Vector2 jumpPw = new Vector2(0, jump);          //ジャンプさせるベクトルを作る
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);    //瞬間的な力を加える
            goJump = false; //ジャンプフラグをおろす
        }

        //アニメーション更新

        if (isDashing)
        {
            //ダッシュ中
            nowAnime = dashAnime;
        }

        else if (onGround)
        {
            //地面の上
            //if(axisH==0)
            if (Mathf.Abs(axisH) < 0.1f)
            {
                nowAnime = stopAnime;   //停止中
            }
            else
            {
                nowAnime = moveAnime;   //移動
            }
        }
        else
        {
            //空中
            nowAnime = jumpAnime;
        }
        if(nowAnime !=oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime, 0, 0f);  //アニメーション再生


            Debug.Log(nowAnime);
        }
    }

    //----------------------------------------------
    //ジャンプ
    public void Jump()
    {
        goJump = true;  //ジャンプフラグを立てる
    }

    //ダッシュ
    public void Dash()
    {
        canDash = false;
        isDashing = true;

        //ダッシュのアニメーションにすぐ切り替える
        animator.Play(dashAnime, 0, 0f);

        //今の速度を一回消す
        rbody.linearVelocity = Vector2.zero;

        ////向いている方向へ力を加える
        float dir = Mathf.Sign(transform.localScale.x);

        //ダッシュ
        Vector2 dash = new Vector2(dir * dashPower, 0);

        rbody.AddForce(dash, ForceMode2D.Impulse);

        //少し後に解除
        Invoke("EndDash", 0.2f);

        //クールタイム開始
        Invoke("ResetDash", dashCoolTime);
    }

    void EndDash()
    {
        isDashing = false;
    }
    void ResetDash()
    {
        canDash = true;
        Debug.Log("ダッシュ使用可能");
    }

    //---------------------------------------------

    //接触開始
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Goal")
        {
            Goal();     //ゴール！！
        }
        else if(collision.gameObject.tag=="Dead")
        {
            GameOver(); //ゲームオーバー
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Damage(1);
        }
    }
    //ゴール
    public void Goal()
    {
        animator.Play(goalAnime);

        gameState = "gameclear";
        GameStop(); //ゲーム停止
    }
    //ゲームオーバー
    public void GameOver()
    {
        animator.Play(deadAnime);

        gameState = "gameover";
        GameStop(); //ゲーム停止
        ////----------------------------
        ////ゲームオーバー演出
        ////----------------------------
        ////プレイヤーあたりを消す
        //GetComponent<CapsuleCollider2D>().enabled = false;
        ////プレイヤーを上に少しあげる演出
        //rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

    }
    //ダメージくらった時用
    public void Damage(int damage)
    {
        if (isInvincible)
        {
            return;
        }

        life -= damage;

        Debug.Log("残り体力：" + life);

        if (life <= 0)
        {
            GameOver();
        }
    }
    //ゲーム中
    void GameStop()
    {
        //Rigidbody2Dを取ってくる
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        //速度を0にして強制停止
        rbody.linearVelocity = new Vector2(0, 0);
    }
    public void GiveItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.Bullet:
                hasBullet = true;
                BulletCount = 3;
                break;

            case ItemType.Hammer:
                hasHammer = true;
                HammerCount = 1;
                break;

            case ItemType.Heart:
                hasHeart = true;
                HeartCount = 1;
                break;

            case ItemType.Heaven:
                hasHeaven = true;
                HeavenCount = 1;
                break;

            case ItemType.Invincibl:
                hasInvincibl = true;
                InvinciblCount = 1;
                break;

            case ItemType.Jump:
                hasJump = true;
                JumpCount = 1;
                break;

            case ItemType.NoSkill:
                hasNoSkill = true;
                NoSkillCount = 1;
                break;

            case ItemType.Shoes:
                hasShoes = true;
                ShoesCount = 1;
                break;

            case ItemType.TimeReset:
                hasTimeReset = true;
                TimeResetCount = 1;
                break;
        }

        Debug.Log("開始時アイテム取得：" + item);
    }
}

