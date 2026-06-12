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
            FPlayerController player =
                other.GetComponent<FPlayerController>();

            // ダメージ
          player.Damage(1, transform.position);

            Debug.Log("残り体力：" + player.life);

            if (player.life <= 0)
            {
                DeadText.text = "GameOver";
                timerManager.Dead();
            }
        }
    }
}