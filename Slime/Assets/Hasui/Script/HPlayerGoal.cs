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
        if (other.CompareTag("Player"))
        {
            //ゴールした時の処理
            //テキスト表示
            GoalText.text = "Goal!";
            //タイム保存
            timerManager.Goal();
        }
    }
}