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

        return minutes.ToString("00") + "m" +
               seconds.ToString("00") + "s";
    }
}