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

    private float timer;

    //タイマーストップ用フラグ
    private bool isRunning = true;
    void Start()
    {
        //クリア判定初期化
        isClear = false;
    }

    void Update()
    {
        if (isRunning)
        {
            //時間を加算
            timer += Time.deltaTime;
        }

        //分と秒
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        //画面に表示
        timerText.text =
            minutes.ToString("00") + "m" +
            seconds.ToString("00") + "s";
    }

    //ゴールしたとき
    public void Goal()
    {
        Debug.Log("Goal");

        //タイマーストップ
        isRunning = false;

        //クリア判定
        isClear = true;

        //タイム保存
        clearTime = timer;

        StartCoroutine(LoadResultScene());
    }

    //死亡したとき
    public void Dead()
    {
        Debug.Log("Dead");

        //タイマーストップ
        isRunning = false;

        //死亡判定
        isClear = false;

        StartCoroutine(LoadResultScene());
    }

    IEnumerator LoadResultScene()
    {
        //三秒間その画面でとどまる
        yield return new WaitForSeconds(3f);

        //リザルトシーン移動
        SceneManager.LoadScene("ResultScene");
    }
}