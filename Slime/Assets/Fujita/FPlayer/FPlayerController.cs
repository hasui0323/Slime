using UnityEngine;

public class FPlayerController : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D型の変数
    float axisH = 0.0f;             //入力
    public float speed = 3.0f;      //移動速度

    public float jump = 9.0f;       //ジャンプ力
    public LayerMask groundLayer;   //着地できるレイヤー
    bool goJump = false;            //ジャンプ開始フラグ

    //アニメーション対応
    Animator animator;     //アニメーター
    public string stopAnime = "FPlayerStop";
    public string moveAnime = "FPlayerMove";
    public string jumpAnime = "FPlayerJump";
    public string goalAnime = "FPlayerGoal";
    public string deadAnime = "FPlayerOver";
    public string nowAnime = "";
    public string oldAnime = "";

    public static string gameState = "playing";//ゲームの状態

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();     //Rigidbody2Dを取ってくる
        animator = GetComponent<Animator>();        //Animatorを取ってくる
        nowAnime = stopAnime;                       //停止から開始する
        oldAnime = stopAnime;                       //停止から開始する

        gameState = "playng";   //ゲーム中にする
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState!="playing")
        {
            return;
        }

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
    }

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

        //プレイヤーの横の速さを変えている
        rbody.linearVelocity = new Vector2(axisH * speed, rbody.linearVelocity.y);

        if (onGround&&goJump)
        {
            //地面でジャンプキーが押された
            //ジャンプさせる
            Vector2 jumpPw = new Vector2(0, jump);          //ジャンプさせるベクトルを作る
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);    //瞬間的な力を加える
            goJump = false; //ジャンプフラグをおろす
        }

        //アニメーション更新
        if(onGround)
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
    //ジャンプ
    public void Jump()
    {
        goJump = true;  //ジャンプフラグを立てる
    }

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
    }
    //ゴール
    public void Goal()
    {
        animator.Play(goalAnime);
    }
    //ゲームオーバー
    public void GameOver()
    {
        animator.Play(deadAnime);
    }

}
