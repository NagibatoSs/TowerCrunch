using TMPro;
using UnityEngine;

public class PointsUIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text pointsValueText;
    [SerializeField] PointsManager pointsManager;

    private void OnEnable()
    {
        pointsManager.OnPointsChanged += AddPoint;
    }
    private void OnDisable()
    {
        pointsManager.OnPointsChanged -= AddPoint;
    }
    private void AddPoint(int pointsCount)
    {
        pointsValueText.text = pointsCount.ToString();
    }
}
