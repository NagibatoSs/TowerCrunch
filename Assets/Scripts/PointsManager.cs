using System;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TowerManager towerManager;
    public event Action<int> OnPointsChanged;
    private int pointsCount = 0;

    private void OnEnable()
    {
        towerManager.OnCrunch += AddPoint;
    }
    private void OnDisable()
    {
        towerManager.OnCrunch -= AddPoint;
    }

    private void AddPoint()
    {
        EncreasePoints(1);
    }

    private void EncreasePoints(int points)
    {
        pointsCount += points;
        OnPointsChanged?.Invoke(pointsCount);
    }
}
