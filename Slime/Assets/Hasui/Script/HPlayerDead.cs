using UnityEngine;
using UnityEngine.UI;

public class HPlayerDead : MonoBehaviour
{
    public TimerManager timerManager;
    public Text DeadText;

    void Start()
    {
        DeadText.text = "";
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //死亡した時の処理
            //テキスト表示
            DeadText.text = "GameOver";
            timerManager.Dead();
        }
    }
}
