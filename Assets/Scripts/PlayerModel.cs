using System;
using UnityEngine;

[Serializable]
public class PlayerModel
{
    [SerializeField] private int coin;
    [SerializeField] private int lastLevelNumber;
    public Action<int> OnCoinsChanged;

    public int Coin
    {
        get => coin;
        set 
        {
            if (value < 0) return;
            coin = value;
            OnCoinsChanged?.Invoke(coin);
        }
    }

    public int LastLevelNumber
    {
        get => lastLevelNumber;
        set
        {
            if (value < 0 || value<lastLevelNumber) return;
            lastLevelNumber = value;
        }
    }
}
