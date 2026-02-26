using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SFXGameBinder : MonoBehaviour
{
    [SerializeField] private TowerManager towerManager;
    [SerializeField] private SFXController sfxPlayer;

    [SerializeField] private SFXData crunchSFX;
    [SerializeField] private SFXData blockSetSFX;

    private void OnEnable()
    {
        towerManager.OnBlockAdded += HandleBlockAdded;
        towerManager.OnCrunch += HandleCrunch;
    }

    private void OnDisable()
    {
        towerManager.OnBlockAdded -= HandleBlockAdded;
        towerManager.OnCrunch -= HandleCrunch;
    }

    private void HandleBlockAdded()
    {
        sfxPlayer.Play(blockSetSFX);
    }

    private void HandleCrunch()
    {
        sfxPlayer.Play(crunchSFX);
    }
}
