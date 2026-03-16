using TMPro;
using UnityEngine;

public class TimeUIHandler : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] TMP_Text elapsedTimeText;

    private void OnEnable()
    {
        int minutes = timer.ElapsedTime / 60;
        int seconds = timer.ElapsedTime % 60;

        elapsedTimeText.text = $"{minutes:00}:{seconds:00}";
    }
}
