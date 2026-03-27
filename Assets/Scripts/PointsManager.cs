using System;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField] TowerManager towerManager;
    public event Action<int> OnCoinsChanged;
    private int coinsCount = 0;
    public int CoinsCount => coinsCount;

    private void OnEnable()
    {
        towerManager.OnCrunch += AddCoin;
    }
    private void OnDisable()
    {
        towerManager.OnCrunch -= AddCoin;
    }
    public void ResetCoinsCount()
    {
        coinsCount = 0;
        OnCoinsChanged?.Invoke(coinsCount);
    }

    private void AddCoin(GameObject block)
    {
        coinsCount ++;
        OnCoinsChanged?.Invoke(coinsCount);
    }

    //private void EncreasePoints(int coins)
    //{
    //    coinsCount += coins;
    //    OnCoinsChanged?.Invoke(coinsCount);
    //}
}
