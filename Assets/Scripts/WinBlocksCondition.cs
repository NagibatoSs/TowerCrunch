using System;
using UnityEngine;

public class WinBlocksCondition : MonoBehaviour
{
    [SerializeField] TowerManager towerManager;
    [SerializeField] GameStateMachine gameStateMachine;
    [SerializeField] LevelInitializer levelInitializer;

    private void OnEnable()
    {
        towerManager.OnBlockAdded += CheckWin;
    }
    private void OnDisable()
    {
        towerManager.OnBlockAdded -= CheckWin;
    }

    private void CheckWin(GameObject block)
    {
        if (towerManager.BlocksCount >= levelInitializer.TargetHeight)
        {
            gameStateMachine.SetWin();
        }
    }
}
