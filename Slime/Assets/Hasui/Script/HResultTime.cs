using UnityEngine;
using UnityEngine.UI;

public class HResultTime : MonoBehaviour
{
    public Text resultText;

    public Text firstText;
    public Text secondText;
    public Text thirdText;

    //ランキング保存用
    static float first = 9999f;
    static float second = 9999f;
    static float third = 9999f;

    void Start()
    {

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
            firstText.text = "1st : " + FormatTime(first);
            secondText.text = "2nd : " + FormatTime(second);
            thirdText.text = "3rd : " + FormatTime(third);
        
    }

    void UpdateRanking(float newTime)
    {
        //1位更新
        if (newTime < first)
        {
            third = second;
            second = first;
            first = newTime;
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

        return minutes.ToString("00") + ":" +
               seconds.ToString("00");
    }
}