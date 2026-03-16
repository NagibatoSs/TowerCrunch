using TMPro;
using UnityEngine;

public class PointsUIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text pointsValueText;
    [SerializeField] PointsManager pointsManager;

    private void OnEnable()
    {
        pointsManager.OnCoinsChanged += AddPoint;
    }
    private void OnDisable()
    {
        pointsManager.OnCoinsChanged -= AddPoint;
    }
    private void AddPoint(int pointsCount)
    {
        pointsValueText.text = pointsCount.ToString();
    }
}
