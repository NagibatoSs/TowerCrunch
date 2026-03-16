using UnityEngine;

public class LevelDataReseter : MonoBehaviour
{
    [SerializeField] GameStateMachine gameStateMachine;
    [SerializeField] TowerManager towerManager;
    [SerializeField] PointsManager pointsManager;
    [SerializeField] TowerHeightManager heightManager;
    [SerializeField] Timer timer;
    public void CleanData()
    {
        towerManager.ResetTower();
        pointsManager.ResetCoinsCount();
        heightManager.ResetHeight();
        timer.PauseTimer();
    }
}
