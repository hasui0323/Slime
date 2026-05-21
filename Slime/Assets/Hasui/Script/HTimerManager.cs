using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour
{
    //ResultScene用
    public static float clearTime;

    //表示用
    public Text timerText;

    private float timer;

    //タイマーストップ用フラグ
    private bool isRunning = true;

    void Update()
    {
        if(isRunning)
        {
            //時間を加算
            timer += Time.deltaTime;
        }
       

        //分と秒
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        //画面に表示
        timerText.text =
            minutes.ToString("00") + ":" +
            seconds.ToString("00");
    }

    //ゴールしたとき
    public void Goal()
    {
        isRunning = false;

        //ResultSceneへ値を渡す
        clearTime = timer;

        new WaitForSeconds(3f);
        // 3秒待ってからシーン移動
        StartCoroutine(LoadResultScene());
    }

    IEnumerator LoadResultScene()
    {
        // 3秒待機
        yield return new WaitForSeconds(3f);

        // シーン移動
        SceneManager.LoadScene("ResultScene");
    }
}
