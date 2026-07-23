using UnityEngine;
using System.Collections;

public class FEffectItem : MonoBehaviour
{
    FPlayerController player;
    Rigidbody2D rbody;

    //public float SpeedUpValue = 3.0f; // 増加量
    public float InvinciblTime = 8.0f;  // 無敵持続時間
    public float RemoveCoolTime = 5.0f;// ダッシュのクールタイムをなくす時間

    public HItemUI ItemUI;

    bool isInvincibleRunning = false;
    bool isTimeResetRunning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<FPlayerController>();
        rbody = GetComponent<Rigidbody2D>();

        ItemUI = FindFirstObjectByType<HItemUI>();

        if (player.hasHeart)
            ItemUI.ShowItemInfo("残り " + player.HeartCount + " 回");

        else if (player.hasHeaven)
            ItemUI.ShowItemInfo("残り " + player.HeavenCount + " 回");

        else if (player.hasNoSkill)
            ItemUI.ShowItemInfo("残り " + player.NoSkillCount + " 回");

        else if (player.hasInvincibl)
            ItemUI.ShowItemInfo("残り " + InvinciblTime + " 秒");

        else if (player.hasTimeReset)
            ItemUI.ShowItemInfo("残り " + RemoveCoolTime + " 秒");
    }

    // Update is called once per frame
    void Update()
    {
        if (FPlayerController.gameState != "playing")
        {
            return;
        }

        // NoSkillアイテム
        if (player.hasNoSkill)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("NoSkill使用");

                player.NoSkillCount--;

                ItemUI.ShowItemInfo("残り " + player.NoSkillCount + " 回");

                if (player.NoSkillCount <= 0)
                {
                    player.hasNoSkill = false;

                    ItemUI.ClearItem();
                }

                //SE再生(Buff)
                FSoundManager.soundManager.SEPlay(SEType.Buff);
            }
        }

        //Haertアイテムを持っている時だけ発動できる
        if (player.hasHeart)
        {
            //Xキーで発射
            if (Input.GetKeyDown(KeyCode.X))
            {
                // 体力を1増やす
                player.life += 1;

                player.HeartCount--;

                //プレイヤーの体力が3より大きくならないようにするための処理
                if(player.life > 3 )
                {
                    player.life = 3;
                }

                ItemUI.ShowItemInfo("残り " + player.HeartCount + " 回");

                if (player.HeartCount <= 0)
                {
                    player.hasHeart = false;
                    ItemUI.ClearItem();
                }

                //SE再生(Buff)
                FSoundManager.soundManager.SEPlay(SEType.Buff);
            }
        }

        //Invinciblアイテムを持っている時だけ発動できる
        if (player.hasInvincibl && !isInvincibleRunning)
        {
            //Xキーで発射
            if (Input.GetKeyDown(KeyCode.X))
            {
                // 無敵開始
                player.isItemInvincible = true;

                // 8秒後に無敵解除
                //Invoke("EndInvincible", InvinciblTime);

                player.InvinciblCount--;

                StartCoroutine(InvincibleTimer());

                Debug.Log("無敵発動！");


                //SE再生(Buff)
                FSoundManager.soundManager.SEPlay(SEType.Buff);
            }
        }

        //Hevenアイテムを持っている時だけ発動できる
        if (player.hasHeaven)
        {
            //Xキーで発射
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (Random.value < 0.5f)
                {
                    // 当たり
                    player.speed += 4.0f;
                    Debug.Log("当たり！スピードアップ！");
                }
                else
                {
                    // ハズレ
                    Debug.Log("ハズレ！即死！");
                    player.GameOver();
                }

                player.HeavenCount--;

                ItemUI.ShowItemInfo("残り " + player.HeavenCount + " 回");

                if (player.HeavenCount <= 0)
                {
                    player.hasHeaven = false;
                    ItemUI.ClearItem();
                }

                //SE再生(Buff)
                FSoundManager.soundManager.SEPlay(SEType.Buff);
            }
        }

        //TimeResetアイテムを持っている時だけ発動できる
        if (player.hasTimeReset && !isTimeResetRunning)
        {
            //Xキーで発射
            if (Input.GetKeyDown(KeyCode.X))
            {
                // クールタイムを0.3秒にする
                player.dashCoolTime = 0.3f;

                // 10秒後にクールタイムなし解除
                //Invoke("EndTimeReset", RemoveCoolTime);

                player.TimeResetCount--;

                StartCoroutine(TimeResetTimer());

                Debug.Log("ダッシュクールタイム短縮！");

                //SE再生(Buff)
                FSoundManager.soundManager.SEPlay(SEType.Buff);
            }
        }

    }


    void EndInvincible()
    {
        player.isItemInvincible = false;

        Debug.Log("無敵終了");
    }
    void EndTimeReset()
    {
        player.dashCoolTime = player.normalDashCoolTime;

        Debug.Log("クールタイム短縮終了");
    }

    IEnumerator InvincibleTimer()
    {
        isInvincibleRunning = true;

        float timer = InvinciblTime;

        while (timer > 0)
        {
            ItemUI.ShowItemInfo("残り " +
                Mathf.CeilToInt(timer) + " 秒");

            timer -= Time.deltaTime;
            yield return null;
        }

        ItemUI.ShowItemInfo("残り 0 秒");

        yield return new WaitForSeconds(0.3f);

        ItemUI.ClearItem();

        EndInvincible();

        player.hasInvincibl = false;
        player.InvinciblCount = 0;

        isInvincibleRunning = false;
    }

    IEnumerator TimeResetTimer()
    {
        isTimeResetRunning = true;

        float timer = RemoveCoolTime;

        while (timer > 0)
        {
            ItemUI.ShowItemInfo("残り " +
                Mathf.CeilToInt(timer) + " 秒");

            timer -= Time.deltaTime;
            yield return null;
        }

        ItemUI.ShowItemInfo("残り 0 秒");

        yield return new WaitForSeconds(0.3f);

        ItemUI.ClearItem();

        EndTimeReset();

        player.hasTimeReset = false;
        player.TimeResetCount = 0;

        isTimeResetRunning = false;
    }
}
