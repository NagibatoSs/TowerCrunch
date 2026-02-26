using UnityEngine;

public class LosePlane : MonoBehaviour
{
    [SerializeField] TowerManager towerManager;
    [SerializeField] GameStateMachine gameStateMachine;
    private void OnTriggerEnter(Collider other)
    {
        if (towerManager.TowerRoot == other.gameObject)
            return;
        else
            gameStateMachine.SetEndGame();
    }
}
