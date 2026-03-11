using System;
using UnityEngine;

public class TowerHeightManager : MonoBehaviour
{
    [SerializeField] TowerManager towerManager;
    public event Action<int> OnHeightChanged;
    private int height = 0;

    private void OnEnable()
    {
        towerManager.OnBlockAdded += EncreaseHeight;
        towerManager.OnCrunch += DecreaseHeight; 
    }
    private void OnDisable()
    {
        towerManager.OnBlockAdded -= EncreaseHeight;
        towerManager.OnCrunch -= DecreaseHeight;
    }
    private void EncreaseHeight()
    {
        height++;
        OnHeightChanged?.Invoke(height);
    }
    private void DecreaseHeight()
    {
        height--;
        OnHeightChanged?.Invoke(height);
    }
}
