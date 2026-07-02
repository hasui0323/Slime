using UnityEngine;
using UnityEngine.UI;

public class HPlayerGoal : MonoBehaviour
{
    public TimerManager timerManager;
    public Text GoalText;

    void Start()
    {
        GoalText.text = "";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //ゴールした時の処理
        if (other.CompareTag("Player"))
        {
            //テキスト表示
            GoalText.text = "Goal!";
            //タイム保存
            timerManager.Goal();
        }
    }
}