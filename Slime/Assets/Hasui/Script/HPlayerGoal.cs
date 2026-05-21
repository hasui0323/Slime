using UnityEngine;

public class HPlayerGoal : MonoBehaviour
{
  public TimerManager timerManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //ƒS[ƒ‹‚µ‚½‚Ìˆ—
            timerManager.Goal();
        }
    }
}