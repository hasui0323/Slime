using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour
{
    //ResultScene用
    public static float clearTime;

    //クリア判定
    public static bool isClear;

    //表示用
    public Text timerText;
    public Text startText;

    //BoxCollider
    private BoxCollider boxCollider;

    private float timer;

    //タイマーストップ用フラグ
    private bool isRunning = false;

    //カウントダウン表示用
    private int countdown = 3;

    //プレイヤー停止用
    public FPlayerController playerController;

    void Start()
    {
        //クリア判定初期化
        isClear = false;

        //タイマーテキスト非表示
        timerText.enabled = false;

        //プレイヤー停止
        playerController.enabled = false;

        //カウントダウン開始
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        //タイマー動作中
        if (isRunning)
        {
            //時間を加算
            timer += Time.deltaTime;

            //分と秒
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            int milliseconds = Mathf.FloorToInt((timer % 1) * 100);

            //画面に表示
            timerText.text =
                minutes.ToString("00") + ":" +
                seconds.ToString("00") + "." +
                milliseconds.ToString("00");

        }
    }

    //カウントダウン処理
    IEnumerator StartCountdown()
    {
        while (countdown > 0)
        {
            //3 → 2 → 1 を表示
            startText.text = countdown.ToString();

            yield return new WaitForSeconds(1f);

            countdown--;
        }

        //START表示
        startText.text = "START!";

        yield return new WaitForSeconds(1f);

        //START文字を消す
        startText.text = "";

        //タイマー表示
        timerText.enabled = true;

        //プレイヤーを動かせるように
        playerController.enabled = true;

        //タイマースタート
        isRunning = true;
    }

    //ゴールしたとき
    public void Goal()
    {
        Debug.Log("Goal");

        isRunning = false;

        isClear = true;

        clearTime = timer;

        StartCoroutine(LoadResultScene());
    }

    //死亡したとき
    public void Dead()
    {
        Debug.Log("Dead");

        isRunning = false;

        isClear = false;

        StartCoroutine(LoadResultScene());
    }

    IEnumerator LoadResultScene()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("ResultScene");
    }
}