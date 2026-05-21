using UnityEngine;

public class HPlayerDead : MonoBehaviour
{
    public TimerManager timerManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //€–S‚µ‚½‚Ìˆ—
            timerManager.Dead();
        }
    }
}
