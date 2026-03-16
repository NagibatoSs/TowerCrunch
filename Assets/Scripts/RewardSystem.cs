using System;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    [SerializeField] GameStateMachine gameStateMachine;
    [SerializeField] PlayerScriptableModel playerScriptableModel;
    [SerializeField] PointsManager pointManager;
    public Action<int, int> OnReward;
    private void OnEnable()
    {
        gameStateMachine.OnStateChanged += Reward;
    }
    private void OnDisable()
    {
        gameStateMachine.OnStateChanged -= Reward;
    }

    private void Reward(GameState state)
    {
        if (state == GameState.Win)
        {
            OnReward?.Invoke(playerScriptableModel.Model.Coin, pointManager.CoinsCount);
            RewardCoins();
            SetNewNextLevel();
            playerScriptableModel.Save();
        }
    }
    private void RewardCoins()
    {
        playerScriptableModel.Model.Coin += pointManager.CoinsCount;
    }
    private void SetNewNextLevel()
    {
        playerScriptableModel.Model.LastLevelNumber++;
    }
}
