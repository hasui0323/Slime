using UnityEngine;
using UnityEngine.UI;

public class HResultTime : MonoBehaviour
{
    public Text resultText;

    public Text firstText;
    public Text secondText;
    public Text thirdText;

    //New Record Text表示用
    public Text NewrecordText;

    //ランキング保存用
    static float first = 9999f;
    static float second = 9999f;
    static float third = 9999f;

    //ゲーミング表示ON/OFF
    bool isNewRecord = false;

    void Start()
    {
        //常に表示しないため
        NewrecordText.gameObject.SetActive(false);

        if (TimerManager.isClear)
        {
            //今回のタイム
            float time = TimerManager.clearTime;

            //今回タイム表示
            resultText.text = FormatTime(time);

            //ランキング更新
            UpdateRanking(time);

        }
        else
        {
            //死亡時に表示するのテキスト
            resultText.text = "GAME OVER";
        }
            //ランキング表示
            firstText.text = FormatTime(first);
            secondText.text = FormatTime(second);
            thirdText.text = FormatTime(third);
        
    }

    void Update()
    {
        //NewRecordTextだけ動かす
        if (isNewRecord)
        {
            //NewRecordTextを虹色にする
            NewrecordText.color = Color.HSVToRGB(Time.time % 1, 1, 1);

            //NewRecordTextを拡大・縮小
            NewrecordText.transform.localScale = Vector3.one * (1 + Mathf.Sin(Time.time * 5) * 0.2f);
        }
    }

    void UpdateRanking(float newTime)
    {
        //1位更新
        if (newTime < first)
        {
            third = second;
            second = first;
            first = newTime;

            //New Record表示用
            NewrecordText.gameObject.SetActive(true);
            NewrecordText.text = "NEW RECORD";

            //Textをゲーミング仕様に変更
            isNewRecord = true;

        }
        //2位更新
        else if (newTime < second)
        {
            third = second;
            second = newTime;
        }
        //3位更新
        else if (newTime < third)
        {
            third = newTime;
        }
    }

    string FormatTime(float time)
    {
        if (time >= 9999f)
        {
            return "--:--";
        }

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time % 1) * 100);

        return minutes.ToString("00") + ":" +
               seconds.ToString("00") + "." +
               milliseconds.ToString("00");
    
    }
}