using UnityEngine;

public class DecideWinnerScript : MonoBehaviour
{
    public RaceManagerScript raceManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Horse"))
        {
            raceManager.DeclareWinner(other.name);
        }
    }
}
