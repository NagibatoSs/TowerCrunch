using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SFXGameBinder : MonoBehaviour
{
    [SerializeField] private TowerManager towerManager;
    [SerializeField] private RewardCoinsUIHandler rewardCoins;
    [SerializeField] private SFXController sfxPlayer;

    [SerializeField] private SFXData crunchSFX;
    [SerializeField] private SFXData blockSetSFX;
    [SerializeField] private SFXData coinSFX;

    private void OnEnable()
    {
        towerManager.OnBlockAdded += PlayBlockAdded;
        towerManager.OnCrunch += PlayCrunch;
        rewardCoins.OnCoinAdd += PlayCoin;
    }

    private void OnDisable()
    {
        towerManager.OnBlockAdded -= PlayBlockAdded;
        towerManager.OnCrunch -= PlayCrunch;
        rewardCoins.OnCoinAdd -= PlayCoin;
    }

    private void PlayBlockAdded(GameObject block)
    {
        sfxPlayer.Play(blockSetSFX);
    }

    private void PlayCrunch(GameObject block)
    {
        sfxPlayer.Play(crunchSFX);
    }

    private void PlayCoin()
    {
        sfxPlayer.Play(coinSFX);
    }
}
