using UnityEngine;
using System.Collections.Generic;

public class RaceManagerScript : MonoBehaviour
{
    public HorseMovementScript[] horses;
    public UIManagerScript uiManager;

    public int selectedHorse = -1;
    private Dictionary<string, int> places = new Dictionary<string, int>();
    // коли перетинає фінішну лінію то його місце зберігається тут

    public void StartRace(int horseIndex)
    {
        selectedHorse = horseIndex;
        places.Clear();

        foreach (HorseMovementScript horse in horses)
        {
            SetupHorse(horse);
        }
    }

    private void SetupHorse(HorseMovementScript horse)
    {
        horse.GetComponent<Animator>().SetTrigger("StartRace");
        horse.StartMove(Random.Range(2.5f, 5f)); // коні рухаються з рандомною швидкістю
    }

    public void DeclareWinner(string horseName)
    {
        places[horseName] = places.Count + 1;

        if (places.Count == horses.Length)
        {
            uiManager.ShowResultPanel(selectedHorse, places);
        }
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}
