using TMPro;
using UnityEngine;

public class TimerUiHandler : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] TMP_Text timerText;

    private void OnEnable()
    {
        timer.OnSecondChanged += UpdateUI;
    }
    private void OnDisable()
    {
        timer.OnSecondChanged -= UpdateUI;
    }

    private void UpdateUI(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
