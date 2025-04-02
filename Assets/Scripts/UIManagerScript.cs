using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManagerScript : MonoBehaviour
{
    /* спочатку показую панель для вибору коня
       Натискаю на кнопку вибору -> кінь зберігається, панель ховається і показую старт
       Після натиску на старт починається гонка */

    public Button startButton;
    public GameObject selectHorsePanel;
    public RaceManagerScript raceManager;
    public GameObject resultPanel;
    public Text resultMessage;

    private int selectedHorse = -1;

    private void Start()
    {
        startButton.gameObject.SetActive(false);
        startButton.onClick.AddListener(StartRace);
    }

    public void StartRace()
    {
        startButton.gameObject.SetActive(false);
        selectHorsePanel.SetActive(false);
        raceManager.StartRace(selectedHorse);
    }

    public void ChooseHorse(int index)
    {
        selectedHorse = index;
        startButton.gameObject.SetActive(true);
        selectHorsePanel.SetActive(false);
    }

    public void ShowResultPanel(int chosenHorse, Dictionary<string, int> places)
    {
        /* Dictionary зберігає місце яке зайняли коні:
           string - ім'я коня
           int - місце, яке він посів */

        resultPanel.SetActive(true);
        string chosenHorseName = "Horse" + (chosenHorse + 1) + "GO";

        resultMessage.text = places.ContainsKey(chosenHorseName)
        ? (places[chosenHorseName] == 1 ? "Your horse won!" : "Your horse is " + places[chosenHorseName])
        : "Race finished!";
    }
}
